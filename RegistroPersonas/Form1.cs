using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroPersonas
{
    public partial class Form1 : Form
    {
        private BindingList<Persona> personas = new BindingList<Persona>();
        private Persona seleccionado = null;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cmbTipo.Items.AddRange(new[] { "Alumno", "Profesor" });
            cmbTipo.SelectedIndex = 0;
            habilitar(true);

            dataLista.AutoGenerateColumns = false;
            dataLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataLista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Columna Nombre
            var colNombre = new DataGridViewTextBoxColumn
            {
                HeaderText = "Nombre",
                DataPropertyName = "Nombre"
            };
            dataLista.Columns.Add(colNombre);

            // Columna Apellido
            var colApellido = new DataGridViewTextBoxColumn
            {
                HeaderText = "Apellido",
                DataPropertyName = "Apellido"
            };
            dataLista.Columns.Add(colApellido);

            // Columna Edad
            var colEdad = new DataGridViewTextBoxColumn
            {
                HeaderText = "Edad",
                DataPropertyName = "Edad"
            };
            dataLista.Columns.Add(colEdad);

            // Columna Tipo (Alumno/Profesor)
            var colTipo = new DataGridViewTextBoxColumn
            {
                HeaderText = "Tipo",
                DataPropertyName = "Tipo" 
            };
            dataLista.Columns.Add(colTipo);

            // Columna InfoExtra (Carrera/Materia)
            var colExtra = new DataGridViewTextBoxColumn
            {
                HeaderText = "Carrera/Materia",
                DataPropertyName = "InfoExtra" 
            };
            dataLista.Columns.Add(colExtra);

            // Asignar la lista al DataGridView
            dataLista.DataSource = personas;
        }
        //Método
        public void limpiarDatos()
        {
            cmbTipo.SelectedIndex = 0;
            txtNombre.Clear();
            txtApellido.Clear();
            txtEdad.Clear();
            txtCarreraMateria.Clear();
            seleccionado = null;
            lblSeleccionado.Text = "";
            habilitar(true);
        }
        public void habilitar(bool accion)
        {
            if (accion)
            {
                btnAgregar.Enabled = true;
                btnModificar.Enabled = false;
            }
            else
            {
                btnAgregar.Enabled = false;
                btnModificar.Enabled = true;
            }
        }
        public bool validarDatos()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Nombre es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show("Apellido es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtApellido.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtEdad.Text))
            {
                MessageBox.Show("Edad es requerida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtApellido.Focus();
                return false;
            }
            if (!int.TryParse(txtEdad.Text, out int edad))
            {
                MessageBox.Show("Edad debe ser un número válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEdad.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtCarreraMateria.Text))
            {
                MessageBox.Show("Carrera/Materia es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtApellido.Focus();
                return false;
            }
            return true;
        }
        private void cargarPersona(Persona persona)
        {
            seleccionado = persona;
            if(persona != null)
            {
                lblSeleccionado.Text = persona.MostrarDatos();
                txtNombre.Text = persona.Nombre;
                txtApellido.Text = persona.Apellido;
                txtEdad.Text = persona.Edad.ToString();
                if (seleccionado is Alumno a)
                {
                    cmbTipo.SelectedIndex = 0;
                    txtCarreraMateria.Text = a.Carrera;
                } else if (seleccionado is Profesor p)
                {
                    cmbTipo.SelectedIndex = 1;
                    txtCarreraMateria.Text = p.Materia;
                }
            }
            else
            {
                lblSeleccionado.Text = "";
            }
            
        }
        //Acciones
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                Persona persona = null;
                if (cmbTipo.SelectedItem.ToString() == "Alumno")
                {
                    persona = new Alumno
                    {
                        Nombre = txtNombre.Text.Trim(),
                        Apellido = txtApellido.Text.Trim(),
                        Edad = int.Parse(txtEdad.Text),
                        Carrera = txtCarreraMateria.Text.Trim(),
                    };
                }
                else if (cmbTipo.SelectedItem.ToString() == "Profesor")
                {
                    persona = new Profesor
                    {
                        Nombre = txtNombre.Text.Trim(),
                        Apellido = txtApellido.Text.Trim(),
                        Edad = int.Parse(txtEdad.Text),
                        Materia = txtCarreraMateria.Text.Trim(),
                    };
                }
                if (personas != null)
                {
                    personas.Add(persona);
                    limpiarDatos();
                }
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(seleccionado != null && validarDatos())
            {
                seleccionado.Nombre = txtNombre.Text.Trim();
                seleccionado.Apellido = txtApellido.Text.Trim();
                seleccionado.Edad = int.Parse(txtEdad.Text);
                if (seleccionado is Alumno a)
                {
                    a.Carrera = txtCarreraMateria.Text.Trim();
                } else if (seleccionado is Profesor p) 
                {
                    p.Materia = txtCarreraMateria.Text.Trim();
                }
                dataLista.Refresh();
                dataLista.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                cargarPersona(seleccionado);
                MessageBox.Show("Datos modificados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("Seleccione una persona para modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            limpiarDatos();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarDatos();
        }
        private void dataLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataLista.Rows.Count)
            {
                var persona = dataLista.Rows[e.RowIndex].DataBoundItem as Persona;
                cargarPersona(persona);
                habilitar(false);
            }
        }
        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipo = cmbTipo.SelectedItem.ToString();
            if (tipo == "Alumno")
            {
                lblMC.Text = "Carrera:";
            }
            else if (tipo == "Profesor")
            {
                lblMC.Text = "Materia:";
            }
        }
    }
}
