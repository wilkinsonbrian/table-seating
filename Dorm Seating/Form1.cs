using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dorm_Seating
{
    public partial class Form1 : Form
    {
        private string staffFileName;
        private string studentFileName;
        private string saveFileName;
        ProgressBar pBar1 = new ProgressBar();

        public Form1()
        {
            InitializeComponent();

            // Disables the ability to load the staff file and create the seating chart.
            // User will load students, then staff, then create seating chart.
            createSeating.Enabled = false;
            loadStaff.Enabled = false;
            pBar1.Location = new Point(3, 90);
            flowLayoutPanel2.Controls.Add(pBar1);
        }

        /// <summary>
        /// Prompts the user for a file containing student information.  Currently
        /// each line of the file should consist of a students name followed by a comma and then
        /// whether the student is (d)omestic or (i)nternational
        /// 
        /// e.g. Brian Wilkinson,d
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadStudentFile(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string studentList = File.ReadAllText(openFileDialog1.FileName);
                fileBox.Text = studentList;
                studentFileName = openFileDialog1.FileName;
                loadStaff.Enabled = true; // once the student file has been loaded, enable staff file loading button
            }
        }

        /// <summary>
        /// Prompts the user for a text file containing staff information.
        /// File consists of staff name followed by a comma and then the 
        /// number of available seats at that table.
        /// 
        /// e.g. Brian,5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadStaff_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string staffList = File.ReadAllText(openFileDialog1.FileName);
                fileBox.Text = staffList;
                staffFileName = openFileDialog1.FileName;
                createSeating.Enabled = true; // Both files loaded, enable the ability to create the chart
            }
        }

        /// <summary>
        /// Clears whatever happens to be in the text box.
        /// Not sure this is needed, may be removed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            fileBox.Clear();
        }

        /// <summary>
        /// User can make changes to whatever file is currently in the text box.
        /// They will need to overwrite whichever file they are modifying and NOT
        /// save a new one.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveText_Click(object sender, EventArgs e)
        {
            string toBeSaved = fileBox.Text;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, toBeSaved);
            }
            
        }

        /// <summary>
        /// The main part of the program.  Only available after the student and staff files
        /// have been selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createSeating_Click(object sender, EventArgs e)
        {
            const int NUM_WEEKS = 8;  // More than 8 weeks and the recursion runs into trouble.

            List<Student> students = new List<Student>();
            List<Table> tables = new List<Table>();
            GetStudents(students, studentFileName);
            GetTables(tables, staffFileName);
            int totalSeats = GetTotalSeats(tables);

            // Configure the progress bar.
            pBar1.Minimum = 1;
            pBar1.Maximum = NUM_WEEKS;
            pBar1.Step = 1;
            pBar1.Visible = true;

            // Check to make sure that the number of available seats is 
            // the same as the number of students.
            if (totalSeats == students.Count)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    saveFileName = saveFileDialog1.FileName;
                }
                MakeSeatingChart(NUM_WEEKS, students, tables, saveFileName, pBar1);
            }
            else
                MessageBox.Show("Number of students does not equal number of seats", "Error");
        }

        /// <summary>
        /// Reads the students from a text file and adds them to a List. Students are 
        /// added as a Student object.  Country information must be separated by a comma.
        /// </summary>
        /// <param name="students"></param>
        /// <param name="studentFileName"></param>
        private static void GetStudents(List<Student> students, string studentFileName)
        {
            using (StreamReader sr = new StreamReader(studentFileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] sRecord = line.Split(',');
                    Student student = new Student(sRecord[0], sRecord[1]);
                    students.Add(student);
                }
            }
        }

        /// <summary>
        /// Reads the staff and available seating information from a text file.  Staff name
        /// and available seats must be separated by a comma.  Tables are added as a Table object.
        /// </summary>
        /// <param name="tables"></param>
        /// <param name="staffFileName"></param>
        private static void GetTables(List<Table> tables, string staffFileName)
        {
            using (StreamReader sr = new StreamReader(staffFileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] tRecord = line.Split(',');
                    Table newTable = new Table(tRecord[0], Convert.ToInt32(tRecord[1]));
                    tables.Add(newTable);
                }
            }
        }

        /// <summary>
        /// Used to find the total number of seats available.  This number must match
        /// the total number of students.  If not, the number of seats must be changed
        /// at one or more tables.
        /// </summary>
        /// <param name="tables"></param>
        /// <returns></returns>
        private static int GetTotalSeats(List<Table> tables)
        {
            int total = 0;
            foreach (Table table in tables)
            {
                total += table.GetNumSeats();
            }
            return total;
        }


        private static void MakeSeatingChart(int NUM_WEEKS, List<Student> students, List<Table> tables, string saveFileName, ProgressBar pBar1)
        {            
            for (int j = 0; j < NUM_WEEKS; j++)
            {
                ResetWeek(tables, students);
                int NumStudentsSeated = 0;
                SeatRecursive(students, tables, NumStudentsSeated);
                pBar1.PerformStep();
                foreach (Table table in tables)
                {
                    File.AppendAllText(saveFileName, table.GetStaffName());
                    File.AppendAllText(saveFileName, "\n");
                    foreach (Student student in table.GetTableSeating())
                    {
                        File.AppendAllText(saveFileName, student.getName());
                        File.AppendAllText(saveFileName, ",");
                    }
                    File.AppendAllText(saveFileName, "\n");
                    File.AppendAllText(saveFileName, "\n");
                }

                File.AppendAllText(saveFileName, "\f");
            }

            MessageBox.Show("Seating chart has been created", "Done");
        }

        /// <summary>
        /// Clears past week's information so that students can be seated at different tables.
        /// </summary>
        /// <param name="tables"></param>
        /// <param name="students"></param>
        private static void ResetWeek(List<Table> tables, List<Student> students)
        {
            foreach (Table table in tables)
            {
                table.ClearStudents();
            }

            foreach (Student student in students)
            {
                student.UnseatStudent();
            }
        }

        /// <summary>
        /// Recursive function that actually seats all the students at tables, one week at a time.  Base case
        /// occurs when the number of students who have been seated is the same as the total number of students.
        /// The algorithm works by first selecting a random student.  It then starts at the first table and checks to
        /// see if a) there is space for the student and b) the student has not sat at that table during a previous week.
        /// If both are true, the student is added to the list for that table and is then marked as "seated."
        /// If no tables meet that condition, the previous student that had been seated is removed 
        /// and seated at another table.
        /// </summary>
        /// <param name="students"></param>
        /// <param name="tables"></param>
        /// <param name="NumStudentsSeated"></param>
        /// <returns></returns>
        private static bool SeatRecursive(List<Student> students, List<Table> tables, int NumStudentsSeated)
        {
            if (NumStudentsSeated == students.Count()) return true; //base case

            int NextStudent = RandomSelect(students);
            for (int i = 0; i < tables.Count; i++)
            {
                if (tables[i].GetRemainingSeats() > 0 && !students[NextStudent].SatAtTable(i))
                {
                    AddStudentToTable(students, NextStudent, tables, i);
                    students[NextStudent].SeatStudent(); // sets isSeated property to true
                    NumStudentsSeated++;
                    if (SeatRecursive(students, tables, NumStudentsSeated))
                    {
                        return true;
                    }
                    else
                    {
                        RemoveStudentFromTable(students, NextStudent, tables, i);
                        students[NextStudent].UnseatStudent();
                        NumStudentsSeated--;
                    }
                }
            }
            return false;
        }

        private static int RandomSelect(List<Student> students)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, students.Count);

            // if a student has already been seated, pick a new number.
            while (students[randomNumber].HasBeenSeated())
            {
                randomNumber = random.Next(0, students.Count);
            }
            return randomNumber;
        }

        private static void AddStudentToTable(List<Student> students, int NextStudent, List<Table> tables, int i)
        {
            tables[i].AddStudent(students[NextStudent]);
            students[NextStudent].AddTable(i);
        }

        private static void RemoveStudentFromTable(List<Student> students, int NextStudent, List<Table> tables, int i)
        {
            tables[i].RemoveStudent(students[NextStudent]);
            students[NextStudent].RemoveTable(i);
        }

    }

    class Table
    {
        private string Staff;
        private int NumSeats;
        private List<Student> Seating = new List<Student>();

        public Table(string staff, int numSeats)
        {
            this.Staff = staff;
            this.NumSeats = numSeats;
        }

        public string GetStaffName()
        {
            return Staff;
        }

        public int GetNumSeats()
        {
            return NumSeats;
        }

        public void AddStudent(Student student)
        {
            Seating.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            Seating.Remove(student);
        }

        public void ClearStudents()
        {
            Seating.Clear();
        }
        public List<Student> GetTableSeating()
        {
            return Seating;
        }

        public int GetRemainingSeats()
        {
            return NumSeats - Seating.Count;
        }
    }

    class Student
    {
        private string Name;
        private string Country;
        private bool IsSeated = false;
        private List<int> TablesSatAt = new List<int>();

        public Student(string name, string country)
        {
            this.Name = name;
            this.Country = country;
        }

        public string getName()
        {
            return Name;
        }

        public string getCountry()
        {
            return Country;
        }

        public void AddTable(int tableNumber)
        {
            TablesSatAt.Add(tableNumber);
        }

        public void RemoveTable(int tableNumber)
        {
            TablesSatAt.Remove(tableNumber);
        }

        public bool HasBeenSeated()
        {
            return IsSeated;
        }

        public void SeatStudent()
        {
            IsSeated = true;
        }

        public void UnseatStudent()
        {
            IsSeated = false;
        }

        public bool SatAtTable(int tableNumber)
        {
            foreach (int seat in TablesSatAt)
            {
                if (seat == tableNumber) return true;
            }
            return false;
        }
    }
}
