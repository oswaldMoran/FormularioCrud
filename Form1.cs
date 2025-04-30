using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;

namespace PruebaTecnicaFinal
{
    public partial class Form1 : Form
    {
        int id = 0;
        private string connectionString = ConfigurationManager.ConnectionStrings["PruebaTecnicaConnection"].ConnectionString;

        //private string connectionString = "Server=DESKTOP-2P3UIN9;Database=PruebaTecnica;Integrated Security=True;";
        public Form1()
        {
            InitializeComponent();
            LlenarDataGridView("SP_ListarEmpleados", CommandType.StoredProcedure);
        }

        
        private void LlenarDataGridView(string query, CommandType commandType)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.CommandType = commandType;

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("SP_ActualizarEmpleado", connection);
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Id", id);
                        command.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                        command.Parameters.AddWithValue("@Departamento", txtDepartamento.Text);
                        command.Parameters.AddWithValue("@Puesto", txtPuesto.Text);
                        command.Parameters.AddWithValue("@Salario", txtSalario.Text);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Empleado actualizado correctamente.");

                        LimpiarCampos();
                        LlenarDataGridView("SP_ListarEmpleados", CommandType.StoredProcedure); //Refresh
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleciona un empleado para actualizar");
            }
                
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("SP_EliminarEmpleado", connection);
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Id", id);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Empleado eliminado correctamente.");

                        LimpiarCampos();
                        LlenarDataGridView("SP_ListarEmpleados", CommandType.StoredProcedure);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("No se ha podido eliminar, intenta de nuevo");
            }
                
        }


        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDepartamento.Clear();
            txtPuesto.Clear();
            txtSalario.Clear();
        }

        // cargar datos del empleado en Input
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // seleccionar fila válida
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtDepartamento.Text = row.Cells["Apellido"].Value.ToString();
                txtPuesto.Text = row.Cells["Email"].Value.ToString();
                txtSalario.Text = row.Cells["Telefono"].Value?.ToString();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SP_InsertarEmpleado", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    command.Parameters.AddWithValue("@Departamento", txtDepartamento.Text);
                    command.Parameters.AddWithValue("@Puesto", txtPuesto.Text);
                    command.Parameters.AddWithValue("@Salario", txtSalario.Text);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Empleado insertado correctamente.");

                    LimpiarCampos();

                    LlenarDataGridView("SP_ListarEmpleados", CommandType.StoredProcedure); // Refresh DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

      

        private void btnListar_Click(object sender, EventArgs e)
        {
            LlenarDataGridView("SP_ListarEmpleados", CommandType.StoredProcedure);
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LlenarDataGridView("SP_ListarEmpleados", CommandType.StoredProcedure);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                id = (int) selectedRow.Cells["ID"].Value;
                txtNombre.Text = selectedRow.Cells["Nombre"].Value.ToString();
                txtDepartamento.Text = selectedRow.Cells["Departamento"].Value.ToString();
                txtPuesto.Text = selectedRow.Cells["Puesto"].Value.ToString();
                txtSalario.Text = selectedRow.Cells["Salario"].Value.ToString();

            }
        }
    }
}



