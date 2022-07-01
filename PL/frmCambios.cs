using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pjPalmera.BLL;
using pjPalmera.Entities;
using PL;

namespace pjPalmera.PL
{
    public partial class frmCambios : Form
    {
        private int _iditem;
        private decimal _import;

        public int getItem
        {
            get { return _iditem; }
        }

        public decimal getImport
        {
            get { return _import; }
        }
       
        public frmCambios()
        {
            InitializeComponent();
        }



        /// <summary>
        ///  Get invoice by number and send parameter to Search current invoice
        /// </summary>
        /// <param name="number"></param>
        private void GetInvoice(string number)
        { 
            var answer = new DialogResult();
          

            try
            {
                if (this.txtInvoiceNumber.Text != string.Empty)
                {
                    answer = MessageBox.Show("Seguro que desea cargar la Factura No. " + number, "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (answer == DialogResult.Yes)
                    {
                        var FactNum = FacturaBO.ExitsInvoiceDes(int.Parse(number));

                        if (FactNum == true)
                        {
                            MessageBox.Show(FacturaBO.strMensajeBO + " " + number, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            SerchProcess(int.Parse(number));
                        }
                        else if (FactNum == false)
                        {
                            MessageBox.Show(FacturaBO.strMensajeBO + " " + number, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.txtInvoiceNumber.Focus();
                        }
                    }
                    else if (answer == DialogResult.No)
                    {
                        this.txtInvoiceNumber.Focus();
                        return;
                    }
                }
                else if (this.txtInvoiceNumber.Text == string.Empty)
                {
                    MessageBox.Show("Debe indicar un número de factura", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtInvoiceNumber.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtInvoiceNumber.Focus();
                return;
            }
        }

        /// <summary>
        /// Clean Containt in controls
        /// </summary>
        private void CleanControls()
        {
            this.txtInvoiceNumber.Text = "";
            this.txtCustomer.Text = "";
            this.txtDescription.Text = "";
            this.txtPrice.Text = "";
            this.txtQuantity.Text = "";
            this.lblCustomerFavorTotal.Text = "00.00";
            this.lblOriginalTotal.Text = "00.00";
            
        }

        /// <summary>
        /// Not Allow to use this controls
        /// </summary>
        private void DesableControls()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        /// <summary>
        /// All Controls allow only read
        /// </summary>
        private void ReadOnlyControls()
        {
            this.txtPrice.ReadOnly = true;
            this.txtDescription.ReadOnly = true;
            this.txtCustomer.ReadOnly = true;
            this.dgvDetalle.ReadOnly = true;
        }

        /// <summary>
        /// Detail what can to do with this control 
        /// </summary>
        private void DescribeControls()
        {
            this.toolTip1.SetToolTip(this.btnAddItem, "Agragar item a la lista");
            this.toolTip1.SetToolTip(this.btnSearchInvoice, "Buscar productos");
            this.toolTip1.SetToolTip(this.btnNew, "Nueva solicitud");
            this.toolTip1.SetToolTip(this.btnRemoveItem, "Eliminar item de la lista");
            this.toolTip1.SetToolTip(this.btnSave, "Procesar Cambio");
            this.toolTip1.SetToolTip(this.btnSearchInvoice, "Buscar Factura por el numero");
            this.toolTip1.SetToolTip(this.btnSearchProduct, "Buscar Productos");
        }

        /// <summary>
        /// DataGrid Initialitation
        /// </summary>
        private void BuildDataGrid()
        {
            this.Controls.Add(this.dgvDetalle);
            this.dgvDetalle.ColumnCount = 6;
        }

        /// <summary>
        /// Load Head on GridView Item for Invoices
        /// </summary>
        private void LoadHeadGrid()
        {
            //Header Text
            //---------------------------------------------------
            //this.dgvDetalle.Columns[0].HeaderText = "No";
            //this.dgvDetalle.Columns[1].HeaderText = "CODIGO";
            //this.dgvDetalle.Columns[2].HeaderText = "DESCRIPCION";
            //this.dgvDetalle.Columns[3].HeaderText = "CANTIDAD";
            //this.dgvDetalle.Columns[4].HeaderText = "PRECIO";
            //this.dgvDetalle.Columns[4].HeaderText = "ITBIS";
            //this.dgvDetalle.Columns[5].HeaderText = "IMPORTE";


            //Columns Width 
            // -------------------------------------------------
            //this.dgvDetalle.Columns[0].Width = 10;
            //this.dgvDetalle.Columns[1].Width = 10;  
            //this.dgvDetalle.Columns[2].Width = 10;
            //this.dgvDetalle.Columns[3].Width = 10;
            //this.dgvDetalle.Columns[4].Width = 10;  <-----
            //this.dgvDetalle.Columns[5].Width = 15;

            this.dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
           
        }

        /// <summary>
        ///  Search invoices and load in current form controls
        /// </summary>
        /// <param name="number"></param>
        private void SerchProcess(int number)
        {
            var invoices = new VentaEntity();
            var detail = new List<DetalleVentaEntity>();
            
            invoices = FacturaBO.Get_Head_Invoice_ById(number);
            detail = FacturaBO.GetDetail_byInvoiceId(number);

            this.txtCustomer.Text = invoices.clientes;
            this.lblOriginalTotal.Text = Convert.ToString(invoices.total);

            for (int i=0; i < detail.Count; i++)
            {
               invoices.addProduct(detail[i]);
               //this.dgvDetalle.Rows[i].Cells["No"].Value.ToString();
            }
            
            this.dgvDetalle.DataSource = invoices.listProductos;

            // Process 1: Search and load invoice, detail_invoice too.
            // Process 2: Increment stock item that was removed from original invoice detail (Save in 2nd List it)
            // process 3: Update total in original invoice (frond-end and Databases)
            // Process 4: Descrement  stock after add new item to 1st List
            // Process 5: verificate past total than new  generated total

        }


        #region RemoveItems 
        /// <summary>
        /// Remove Items from the Grid
        /// </summary>
        private void RemoveItem()
        {
            var x = this.dgvDetalle.CurrentRow.Index;
            var invoice = new VentaEntity();
            var list = invoice.listProductos;

            try
            {
                _iditem = Convert.ToInt32(x);   // -------------------->
                _import = Convert.ToDecimal(this.dgvDetalle.Rows[x].Cells["IMPORTE"].Value);

                //decimal subtotal, diferencia, descuento, total, tdescuento, rdescuento, pdescuento;
                //total = Convert.ToDecimal(this.txtTotalPagar.Text);
                //subtotal = Convert.ToDecimal(this.txtSubtotal.Text);
                //descuento = Convert.ToDecimal(this.txtDescuento.Text);

                if (this.dgvDetalle.CurrentRow.Index != -1)
                {                                                                   // ------------------> Verify logic code (possible use iteration (For))
                    // invoice.RemoveItem(this.getInvoiceNumber);

                    this.dgvDetalle.Rows.RemoveAt(this.getItem);
                    //this.dgvDetalle.Parent.Refresh();
                    //this.dgvDetalle.Refresh();
                    //diferencia = subtotal - this.Importe; // Subtract amount by item in list
                    //tdescuento = total - diferencia; // not important this line
                    //pdescuento = (diferencia * 10) / 100;
                    //rdescuento = diferencia - pdescuento;
                    //this.txtTotalPagar.Text = Convert.ToString(rdescuento); //Refrest Amount after remove item from the list
                    //this.txtSubtotal.Text = Convert.ToString(diferencia); // Refrest Sub Amount after remove item from the list 
                    //this.txtDescuento.Text = Convert.ToString(pdescuento); // Refrest  Descount  Amount  after remove item from the list          
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        #endregion

        private void frmCambios_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            DescribeControls();
            CleanControls();
            ReadOnlyControls();
            DesableControls();
            //BuildDataGrid();
             LoadHeadGrid();
            this.txtInvoiceNumber.Focus();
            

        }



        private void btnSearchInvoice_Click(object sender, EventArgs e)
        {
            var number = this.txtInvoiceNumber.Text;
            GetInvoice(number);
        }

        private void txtInvoiceNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.btnSearchInvoice.Focus();
            }
        }

        private void txtCodeProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.btnSearchProduct.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            frmProcesarCambios procCambios = new frmProcesarCambios();
            procCambios.ShowDialog(this);
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            var answer = new DialogResult();

            if (this.dgvDetalle.Rows.Count <= 0) //
            {
                MessageBox.Show("Debe comprobar que existen elementos seleccionados o que la misma contiene para Eliminar del Carrito", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtInvoiceNumber.Focus();
                return;
            }

            else if (this.dgvDetalle.Rows.Count > 0)
            {
                answer = MessageBox.Show("Seguro que desea cambiar este producto", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (answer == DialogResult.Yes)
                {
                    RemoveItem();
                }
                else if (answer == DialogResult.No)
                {
                    this.txtCodeProduct.Focus();
                    return;
                }
            }
        }
    }
}
