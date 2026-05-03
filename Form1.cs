using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace STUDENT_MANAGEMENT
{

    public partial class Form1 : Form
    {
        // Database connection with SQL Server
        string connectionString = "Server=MUNANGA\\SQLEXPRESS;Database=HIT_StudentDB;Integrated Security=True;TrustServerCertificate=True;";

        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        // Viewing Records & DataGridView Setup
        private void LoadData()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Students", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvStudents.DataSource = dt;
            }
        }


        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStudents.Rows[e.RowIndex];
                txtStudentID.Text = row.Cells["StudentID"].Value.ToString();
                txtFullName.Text = row.Cells["FullName"].Value.ToString();
                cmbCourse.Text = row.Cells["Course"].Value.ToString();
                dtpEnrollmentDate.Value = Convert.ToDateTime(row.Cells["EnrollmentDate"].Value);
            }
        }

        //Empty events to satisfy the designer
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        //Insert with Validation and use of try-catch
        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFullName.Text))
                    throw new InvalidStudentDataException("Name cannot be blank!");

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Students (FullName, Course, EnrollmentDate) VALUES (@Name, @Course, @Date)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@Course", cmbCourse.Text);
                    cmd.Parameters.AddWithValue("@Date", dtpEnrollmentDate.Value);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    LoadData();
                    lstLogs.Items.Add($"Inserted: {txtFullName.Text}");
                }
            }
            catch (InvalidStudentDataException ex)
            {
                MessageBox.Show("Validation Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("DATABASE ERROR: " + ex.Message);
            }
        }

        //Update
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStudentID.Text)) return;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Students SET FullName=@Name, Course=@Course, EnrollmentDate=@Date WHERE StudentID=@ID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ID", txtStudentID.Text);
                cmd.Parameters.AddWithValue("@Name", txtFullName.Text);
                cmd.Parameters.AddWithValue("@Course", cmbCourse.Text);
                cmd.Parameters.AddWithValue("@Date", dtpEnrollmentDate.Value);

                con.Open();
                cmd.ExecuteNonQuery();
                LoadData();
                lstLogs.Items.Add($"Updated ID: {txtStudentID.Text}");
            }
        }

        // Dlete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Ensure they selected a record
            if (string.IsNullOrEmpty(txtStudentID.Text))
            {
                MessageBox.Show("Please select a student from the grid to delete.", "Action Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // SAFETY NET 2: The confirmation warning box
            DialogResult result = MessageBox.Show(
                $"Are you absolutely sure you want to permanently delete {txtFullName.Text}? This action cannot be undone.",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            // Execute ONLY if they clicked Yes
            if (result == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Students WHERE StudentID=@ID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@ID", txtStudentID.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    LoadData();
                    lstLogs.Items.Add($"Deleted ID: {txtStudentID.Text}");

                    // Clear boxes
                    txtStudentID.Text = ""; txtFullName.Text = "";
                }
            }
        }

        // --- NEW FEATURES FOR TASK 7 ---

        // Export Data to Text File
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = "StudentsBackup.txt";
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    foreach (DataGridViewRow row in dgvStudents.Rows)
                    {
                        if (!row.IsNewRow) // Skip the empty row at the bottom
                        {
                            string name = row.Cells["FullName"].Value.ToString();
                            string course = row.Cells["Course"].Value.ToString();
                            string date = Convert.ToDateTime(row.Cells["EnrollmentDate"].Value).ToString("yyyy-MM-dd");

                            sw.WriteLine($"{name},{course},{date}");
                        }
                    }
                }
                MessageBox.Show("Data successfully exported to StudentsBackup.txt!", "Export Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lstLogs.Items.Add("Data Exported.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Export Error: " + ex.Message);
            }
        }

        // Import Data from Text File
        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = "StudentsBackup.txt";

                if (!File.Exists(filePath))
                {
                    MessageBox.Show("No backup file found to import!", "File Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string[] lines = File.ReadAllLines(filePath);
                int importedCount = 0;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(',');

                        if (parts.Length == 3)
                        {
                            string query = "INSERT INTO Students (FullName, Course, EnrollmentDate) VALUES (@Name, @Course, @Date)";
                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@Name", parts[0]);
                            cmd.Parameters.AddWithValue("@Course", parts[1]);
                            cmd.Parameters.AddWithValue("@Date", parts[2]);

                            cmd.ExecuteNonQuery();
                            importedCount++;
                        }
                    }
                }

                LoadData();
                MessageBox.Show($"{importedCount} records imported successfully!", "Import Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lstLogs.Items.Add($"Imported {importedCount} records.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Import Error: " + ex.Message);
            }
        }
    }

    public class InvalidStudentDataException : Exception
    {
        public InvalidStudentDataException(string message) : base(message) { }
    }
}