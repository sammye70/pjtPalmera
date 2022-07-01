using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pjPalmera.Entities;
using pjPalmera.BLL;
using System.Drawing.Printing;

namespace pjPalmera.PL
{
    public partial class frmConsOpCaja : Form
    {
        UsuariosEntity user = new UsuariosEntity();
        OperationsCajaEntity oCaja = new OperationsCajaEntity();

        int number;

        private int getNumber 
        {
            get { return number;}
        }

        public frmConsOpCaja()
        {
            InitializeComponent();
        }

        private void frmConsOpCaja_Load(object sender, EventArgs e)
        {
            this.getAllOperations();
            this.DisableFields();
            this.DisplayHeaderText();
        }

        /// <summary>
        ///  Prepare controls before load form  by Admin
        /// </summary>
        public void iniControlAdmin()
        {
            this.lblUsers.Visible = true;
            this.cmbListUsers.Visible = true;
          //  this.dtpDateBegin.Format = DateTimePickerFormat.Short;
          //  this.dtpDateEnd.Format = DateTimePickerFormat.Short;
            this.dgvOperationsBox.ReadOnly = true;
            this.dgvOperationsBox.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //---> Add current date before user open form to filter only 

        }


        /// <summary>
        /// Prepare controls before load form  by Not Admin
        /// </summary>
        public void iniControls()
        {
            this.dgvOperationsBox.ReadOnly = true;
            this.dgvOperationsBox.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        /// <summary>
        ///  Validator User Rol
        /// </summary>
        /// <returns> true when rol is 2 and otherwise false</returns>
        private Boolean validatorRol()
        {
            bool ctr = false;
            var rol = this.txtPermission.Text;

            if (rol == "2")
            {
                ctr = true;
            }
            return ctr;
        }


        /// <summary>
        ///  Get all Operations from box history
        /// </summary>
        private void getAllOperations()
        {
            oCaja.UserId = int.Parse(this.txtUserId.Text);
            var bDate = this.dtpDateBegin.Value;
            var uDate = this.dtpDateEnd.Value;

            oCaja.Bdate = bDate.ToString("yyyy-MM-dd");
            oCaja.Udate = uDate.ToString("yyyy-MM-dd");

            if (this.validatorRol() != false)
            {
                this.dgvOperationsBox.DataSource = OperationsCajaBO.GetAllOpBox(oCaja);
            }
                
        }

        /// <summary>
        /// Hide Columns on DataGridView
        /// </summary>
        private void DisableFields()
        {
            if (this.validatorRol() != false)
                this.hideFields();
        }

        /// <summary>
        ///  Display Headers Grid View
        /// </summary>
        private void DisplayHeaderText()
        {
            if (this.validatorRol() != false)
                this.setFieldsDetails();
        }


        /// <summary>
        ///  Get All Operations after admin user selected casher without dates
        /// </summary>
        private void getOperationsByUser()
        {
            try
            {
                var uquery = new UsuariosEntity();
                var objUser = this.cmbListUsers.SelectedItem;
                var bDate = this.dtpDateBegin.Value;
                var uDate = this.dtpDateEnd.Value;

                uquery = (UsuariosEntity)objUser;
                oCaja.UserId = uquery.Id_user;
                oCaja.Bdate = bDate.ToString("yyyy-MM-dd");
                oCaja.Udate = uDate.ToString("yyyy-MM-dd");

                this.dgvOperationsBox.DataSource = null;
                this.dgvOperationsBox.DataSource = OperationsCajaBO.GetAllOpBox(oCaja);

                if (this.dgvOperationsBox.DataSource != null)
                {
                    this.setFieldsDetails();
                    this.hideFields();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        ///  Get All Operations after admin user selected casher and dates ranges (only field date functional it is)
        /// </summary>
        private void getOperationsByUserDateAdm()
        {
            var uquery = new UsuariosEntity();
            var objUser = this.cmbListUsers.SelectedItem;
            DateTime bdate = this.dtpDateBegin.Value;
            DateTime udate = this.dtpDateEnd.Value;


            uquery = (UsuariosEntity) objUser;
            oCaja.UserId = uquery.Id_user;
            oCaja.Bdate = bdate.ToString("yyyy-MM-dd");
            oCaja.Udate = udate.ToString("yyyy-MM-dd");

            this.dgvOperationsBox.DataSource = null;
            this.dgvOperationsBox.DataSource = OperationsCajaBO.getOperationsByUserDate(oCaja);

            if (this.dgvOperationsBox.DataSource != null)
            {
                this.setFieldsDetails();
                this.hideFields();
            }
        }

        /// <summary>
        ///  Get All Operations current user and dates ranges (only field date functional it is by default)
        /// </summary>
        private void getOperationsByUserDate()
        {   
            var bdate = this.dtpDateBegin.Value;
            var udate = this.dtpDateEnd.Value;

            oCaja.UserId = int.Parse(this.txtUserId.Text);
            oCaja.Bdate = bdate.ToString("yyyy-MM-dd");
            oCaja.Udate = udate.ToString("yyyy-MM-dd");

            this.dgvOperationsBox.DataSource = null;
            this.dgvOperationsBox.DataSource = OperationsCajaBO.getOperationsByUserDate(oCaja);
            
            if(this.dgvOperationsBox.DataSource != null)
            {
                this.setFieldsDetails();
                this.hideFields();
            }
        }

        /// <summary>
        ///  Get opened or closed operations by user, dates and type. But user was selected by Admin
        /// </summary>
        private void getOperationsByUserDateType()
        {
            var uquery = new UsuariosEntity();
            var objUser = this.cmbListUsers.SelectedItem;
            var bdate = this.dtpDateBegin.Value;
            var udate = this.dtpDateEnd.Value;
            var optype = this.cmbListProcess.SelectedIndex;

            if(optype != 0)
            {
                uquery = (UsuariosEntity)objUser;
                oCaja.UserId = uquery.Id_user;
                oCaja.Bdate = bdate.ToString("yyyy-MM-dd");
                oCaja.Udate = udate.ToString("yyyy-MM-dd");
                oCaja.TypeOp = optype.ToString();

                this.dgvOperationsBox.DataSource = null;
                this.dgvOperationsBox.DataSource = OperationsCajaBO.GetOpByUserDateType(oCaja);

                if (this.dgvOperationsBox.DataSource != null)
                {
                    this.setFieldsDetails();
                    this.hideFields();
                }
            }
            else
            {
                this.errorProvider1.SetError(this.cmbListProcess, "Debe seleccionar uno de los valores listados");
                this.cmbListProcess.Focus();
            }

        }


        /// <summary>
        ///  Get current transaction Details by Id
        /// </summary>
        private void getOperationById()
        {
            DataGridViewRow x = this.dgvOperationsBox.CurrentRow;

            number = int.Parse(this.dgvOperationsBox.Rows[x.Index].Cells["Id"].Value.ToString());
            oCaja.Id = number;

            oCaja = OperationsCajaBO.getCurrentOperation(oCaja);            
        }


        #region Printing Box Ticket
        /// <summary>
        /// Print Detail from Operations Box Process
        /// </summary>
        /// Bill print Setting
        /// Author: Samuel Estrella
        /// Date: 17/01/2020
        public void PrintTicketOp()
        {
            //Parameters
            PrintDocument pd = new PrintDocument();
            PaperSize pz = new PaperSize("", 420, 520); // Set Paper Size
            pd.PrintPage += Pd_PrintPage;
            

            pd.PrintController = new StandardPrintController();

            pd.DefaultPageSettings.Margins.Left = 0;

            pd.DefaultPageSettings.Margins.Right = 0;

            pd.DefaultPageSettings.Margins.Top = 0;

            pd.DefaultPageSettings.Margins.Bottom = 0;


            try
            {
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Print Ticket Box Process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Parameters
            Font fBody = new Font("Lucida Console", 8, FontStyle.Regular);// Format Font for Body
            Font ffTitle = new Font("Lucida Console", 11, FontStyle.Bold); // Format Font for Title Company Name
            Font fTitle = new Font("Lucida Console", 8, FontStyle.Bold); // Format Font for Title
            Font fdpTitle = new Font("Lucida Console", 8, FontStyle.Regular); // Format Font Detail Products
            Font fpTitle = new Font("Lucida Console", 8, FontStyle.Bold); // Format Font Title Amount
            Font fpBody = new Font("Lucida Console", 8, FontStyle.Bold);// Format number Amount
            Font tbottom = new Font("Lucida Console", 6, FontStyle.Regular); // Format Font Messege Bottom
            Font tblank = new Font("Lucida Console", 19, FontStyle.Bold); // Format Font  Bottom
            Font fdTitle = new Font("Lucida Console", 8, FontStyle.Regular); // Format Font for Detail Title (Address,Telephone, etc.. About Company Information)
            Graphics g = e.Graphics;
            SolidBrush sb = new SolidBrush(Color.Black); // Set Brush color for Drawing Charaters

            // Ticket Titles
            string Type1 = "APERTURA DE LA CAJA";
            string Type2 = "CIERRE DE LA CAJA";

            //Id Invoice
            // this.txtId_Invoice.Text = Convert.ToString(Id_invoice);  //


            RawPrinterHelper j = new RawPrinterHelper(); //

            // Header Ticket

            //int AutoScrollOffset1= -100;
            //AutoScrollOffset1 = AutoScrollOffset1 -100;
            g.DrawString("Farmacia CRM", ffTitle, sb, 75, 120);
            g.DrawString("Donde tu Salud es Nuestra Prioridad", fTitle, sb, 20, 134);
            g.DrawString("C/9, #15, Las Escobas, Jima Arriba", fdTitle, sb, 27, 148);
            g.DrawString("RNC:80700148433", fdTitle, sb, 80, 160);
            g.DrawString("Tel: 809-954-9952", fdTitle, sb, 80, 175);
            g.DrawString("Whatsapp:809-851-2775", fdTitle, sb, 70, 185);

            g.DrawString("FECHA/HORA:", fTitle, sb, 10, 210); //
            g.DrawString(oCaja.Fecha, fBody, sb, 92, 210); //
            g.DrawString("COD. CAJERO:", fTitle, sb, 155, 223); //
            g.DrawString(oCaja.UserId.ToString(), fBody, sb, 240, 223); //
            g.DrawString("NO. OPERACION:", fTitle, sb, 10, 223); //
            g.DrawString(oCaja.Id.ToString(), fBody, sb, 110, 223);
            // g.DrawString(this.txtApClientes.Text, fBody, sb, 180, 220); //
            g.DrawString("MONEDA:", fTitle, sb, 10, 235); //
            g.DrawString("RD$ Pesos", fBody, sb, 95, 235);
            // g.DrawString("NO. OPERACION:", fTitle, sb, 10, 246); // --->
            //g.DrawString(oCaja.Id.ToString(), fBody, sb, 50, 244); //


            // Box Operation  title
            var op = oCaja.TypeOp.ToString();
            switch(op)
            {
                case "2":
                    g.DrawString(Type1, fTitle, sb, 75, 262);
                    break;
                case "3":
                    g.DrawString(Type2, fTitle, sb, 75, 262);
                    break;
            }
           


            // Detail cash

            g.DrawString("-----------------------------------------", fBody, sb, 5, 280);
            g.DrawString("     DETALLES DE OPERACION EN CAJA       ", fdpTitle, sb, 10, 290);
            g.DrawString("-----------------------------------------", fBody, sb, 5, 298);
            g.DrawString(" DENOMINACION     CANTIDAD    MONTO      ", fdpTitle, sb, 6, 304);
            g.DrawString("-----------------------------------------", fBody, sb, 5, 310);

            int AutoScrollOffset = +14;

            // detail open box process
            AutoScrollOffset = AutoScrollOffset + 12;
            g.DrawString("Monedas de 1: ", fdpTitle, sb, 10, 308 + AutoScrollOffset);   // 
            g.DrawString(oCaja.Uno.ToString(), fBody, sb, 158, 308 + AutoScrollOffset);  //
            decimal r1 = 1 * decimal.Parse(oCaja.Uno.ToString());
            g.DrawString(r1.ToString() + ".00", fBody, sb, 212, 308 + AutoScrollOffset);
            g.DrawString("Monedas de 5: ", fdpTitle, sb, 10, 324 + AutoScrollOffset);
            g.DrawString(oCaja.Cinco.ToString(), fBody, sb, 158, 324 + AutoScrollOffset); //
            decimal r2 = 5 * decimal.Parse(oCaja.Cinco.ToString());
            g.DrawString(r2.ToString() + ".00", fBody, sb, 212, 324 + AutoScrollOffset);
            g.DrawString("Monedas de 10: ", fpTitle, sb, 10, 339 + AutoScrollOffset); //
            g.DrawString(oCaja.Diez.ToString(), fpBody, sb, 158, 339 + AutoScrollOffset);  //
            decimal r3 = 10 * decimal.Parse(oCaja.Diez.ToString());
            g.DrawString(r3.ToString() + ".00", fBody, sb, 212, 339 + AutoScrollOffset);
            g.DrawString("Monedas de 25: ", fdpTitle, sb, 10, 356 + AutoScrollOffset);
            g.DrawString(oCaja.Venticinco.ToString(), fBody, sb, 158, 356 + AutoScrollOffset);
            decimal r4 = 25 * decimal.Parse(oCaja.Venticinco.ToString());
            g.DrawString(r4.ToString() + ".00", fBody, sb, 212, 356 + AutoScrollOffset);
            g.DrawString("Billetes de 50: ", fdpTitle, sb, 10, 369 + AutoScrollOffset); //
            g.DrawString(oCaja.Cincuenta.ToString(), fBody, sb, 158, 369 + AutoScrollOffset); //
            decimal r5 = 50 * decimal.Parse(oCaja.Cincuenta.ToString());
            g.DrawString(r5.ToString() + ".00", fBody, sb, 212, 369 + AutoScrollOffset);
            g.DrawString("Billetes de 100: ", fdpTitle, sb, 10, 385 + AutoScrollOffset); //
            g.DrawString(oCaja.Cien.ToString(), fBody, sb, 158, 385 + AutoScrollOffset); //
            decimal r6 = 100 * decimal.Parse(oCaja.Cien.ToString());
            g.DrawString(r6.ToString() + ".00", fBody, sb, 212, 385 + AutoScrollOffset);
            g.DrawString("Billetes de 200: ", fdpTitle, sb, 10, 405 + AutoScrollOffset);
            g.DrawString(oCaja.Doscientos.ToString(), fBody, sb, 158, 405 + AutoScrollOffset);
            decimal r7 = 200 * decimal.Parse(oCaja.Doscientos.ToString());
            g.DrawString(r7.ToString() + ".00", fBody, sb, 212, 405 + AutoScrollOffset);
            g.DrawString("Billetes de 500: ", fdpTitle, sb, 10, 420 + AutoScrollOffset);
            g.DrawString(oCaja.Quinientos.ToString(), fBody, sb, 158, 420 + AutoScrollOffset);
            decimal r8 = 500 * decimal.Parse(oCaja.Quinientos.ToString());
            g.DrawString(r8.ToString() + ".00", fBody, sb, 212, 420 + AutoScrollOffset);
            g.DrawString("Billetes de 1,000: ", fdpTitle, sb, 10, 438 + AutoScrollOffset);
            g.DrawString(oCaja.Mil.ToString(), fBody, sb, 158, 438 + AutoScrollOffset);
            decimal r9 = 1000 * decimal.Parse(oCaja.Mil.ToString());
            g.DrawString(r9.ToString() + ".00", fBody, sb, 212, 438 + AutoScrollOffset);
            g.DrawString("Billetes de 2,000: ", fdpTitle, sb, 10, 458 + AutoScrollOffset);
            g.DrawString(oCaja.Dosmil.ToString(), fBody, sb, 158, 458 + AutoScrollOffset);
            decimal r10 = 2000 * decimal.Parse(oCaja.Dosmil.ToString());
            g.DrawString(r10.ToString() + ".00", fBody, sb, 212, 458 + AutoScrollOffset);

            //Total Amount for this process

            switch (op)
            {
                case "2":
                    AutoScrollOffset = AutoScrollOffset + 8;
                    g.DrawString("Monto Total:", fBody, sb, 119, 478 + AutoScrollOffset);
                    g.DrawString(oCaja.Monto.ToString(), fpBody, sb, 212, 478 + AutoScrollOffset);   //
                    break;

                case "3":
                    AutoScrollOffset = AutoScrollOffset + 8;
                    g.DrawString("Efectivo en Caja:", fdpTitle, sb, 10, 490 + AutoScrollOffset);
                    g.DrawString(this.oCaja.Monto.ToString(), fpBody, sb, 212, 490 + AutoScrollOffset);
                    g.DrawString("Total de Ventas:", fdpTitle, sb, 10, 509 + AutoScrollOffset);
                    g.DrawString(this.oCaja.Venta.ToString(), fpBody, sb, 212, 509 + AutoScrollOffset);
                    g.DrawString("Faltante:", fdpTitle, sb, 10, 58 + AutoScrollOffset);
                    g.DrawString(this.oCaja.Faltante.ToString(), fpBody, sb, 212, 528 + AutoScrollOffset);
                    break;
            }

           

            #region foot/no used this time

            /*  }
               else if (opBoxcl.TypeOp == 2)
               {
                   // detail close box process
                   var closebox = new frmCierreCaja();

                   AutoScrollOffset = AutoScrollOffset + 12;
                   g.DrawString("Monedas de 1:", fdpTitle, sb, 90, 330 + AutoScrollOffset);   // 
                   g.DrawString(closebox.txtMonedas1.Text, fBody, sb, 202, 330 + AutoScrollOffset);  //
                   g.DrawString("Monedas de 5:", fdpTitle, sb, 90, 350 + AutoScrollOffset);
                   g.DrawString(closebox.txtMonedas5.Text, fBody, sb, 202, 350 + AutoScrollOffset); //
                   g.DrawString("Monedas de 10:", fpTitle, sb, 90, 368 + AutoScrollOffset); //
                   g.DrawString(closebox.txtMonedas10.Text, fpBody, sb, 202, 368 + AutoScrollOffset);  //
                   g.DrawString("Monedas de 25", fdpTitle, sb, 100, 370 + AutoScrollOffset);
                   g.DrawString(closebox.txtMonedas25.Text, fBody, sb, 202, 389 + AutoScrollOffset);
                   g.DrawString("Billetes de 50:", fdpTitle, sb, 90, 389 + AutoScrollOffset); //
                   g.DrawString(closebox.txtBilletes50.Text, fBody, sb, 202, 389 + AutoScrollOffset); //
                   g.DrawString("Billetes de 100:", fdpTitle, sb, 90, 405 + AutoScrollOffset); //
                   g.DrawString(closebox.txtBilletes100.Text, fBody, sb, 202, 405 + AutoScrollOffset); //
                   g.DrawString("Billetes de 200:", fdpTitle, sb, 90, 420 + AutoScrollOffset);
                   g.DrawString(closebox.txtBilletes200.Text, fdpTitle, sb, 200, 420 + AutoScrollOffset);
                   g.DrawString("Billetes de 500:", fdpTitle, sb, 90, 420 + AutoScrollOffset);
                   g.DrawString(closebox.txtBilletes500.Text, fdpTitle, sb, 200, 420 + AutoScrollOffset);
                   g.DrawString("Billetes de 1000:", fdpTitle, sb, 90, 420 + AutoScrollOffset);
                   g.DrawString(closebox.txtBilletes1000.Text, fdpTitle, sb, 200, 420 + AutoScrollOffset);
                   g.DrawString("Billetes de 2000:", fdpTitle, sb, 90, 420 + AutoScrollOffset);
                   g.DrawString(closebox.txtBilletes2000.Text, fdpTitle, sb, 200, 420 + AutoScrollOffset);

                   //Total Amount for this process

                   AutoScrollOffset = AutoScrollOffset + 8;
                   g.DrawString("Monto Total de Ventas:", fBody, sb, 5, 426 + AutoScrollOffset);
                   g.DrawString(closebox.lblTotalVentas.Text, fpBody, sb, 100, 426 + AutoScrollOffset);   //
                   g.DrawString("Efectivo en Caja:", fBody, sb, 5, 426 + AutoScrollOffset);
                   g.DrawString(closebox.lblEfectivoCaja.Text, fpBody, sb, 100, 426 + AutoScrollOffset);   //
                   g.DrawString("Diferencia entre Efectivo y Ventas:", fBody, sb, 5, 426 + AutoScrollOffset);
                   g.DrawString(closebox.lblFaltante.Text, fpBody, sb, 100, 426 + AutoScrollOffset);   //
               }
               */

            /*  
             *  //------------------------------------------------------------------------------------> Here begin comment

             // Feet Messenge
             AutoScrollOffset = AutoScrollOffset + 8;
             g.DrawString("Le Atendio:", fBody, sb, 5, 426 + AutoScrollOffset);
             g.DrawString(this.lblCajeroName.Text, fpBody, sb, 100, 426 + AutoScrollOffset);   // Casher First Name and Last Name
             g.DrawString("Nota: no hacemos devoluciones después de la 24 horas,", tbottom, sb, 5, 442 + AutoScrollOffset);
             g.DrawString("y mucho menos si los medicamentos se encuentran en", tbottom, sb, 5, 452 + AutoScrollOffset);
             g.DrawString("mal estado.", tbottom, sb, 5, 462 + AutoScrollOffset);

             g.DrawString("Tú eres la persona más linda que Jesús", fTitle, sb, 5, 482 + AutoScrollOffset);
             g.DrawString("tiene en este mundo Buscale.", fTitle, sb, 5, 497 + AutoScrollOffset);

             g.DrawString(".", tblank, sb, 5, 506 + AutoScrollOffset);
             // 
             */

            #endregion


        }
        #endregion



        /// <summary>
        ///  Hide fields from db
        /// </summary>
        private void hideFields()
        {
            this.dgvOperationsBox.Columns["Uno"].Visible = false;
            this.dgvOperationsBox.Columns["Cinco"].Visible = false;
            this.dgvOperationsBox.Columns["Diez"].Visible = false;
            this.dgvOperationsBox.Columns["Venticinco"].Visible = false;
            this.dgvOperationsBox.Columns["Cien"].Visible = false;
            this.dgvOperationsBox.Columns["Doscientos"].Visible = false;
            this.dgvOperationsBox.Columns["Quinientos"].Visible = false;
            this.dgvOperationsBox.Columns["Mil"].Visible = false;
            this.dgvOperationsBox.Columns["Dosmil"].Visible = false;
            this.dgvOperationsBox.Columns["Userid"].Visible = false;
            this.dgvOperationsBox.Columns["Status"].Visible = false;
            this.dgvOperationsBox.Columns["Cincuenta"].Visible = false;
            this.dgvOperationsBox.Columns["Udate"].Visible = false;
            this.dgvOperationsBox.Columns["Bdate"].Visible = false;
            this.dgvOperationsBox.Columns["Faltante"].Visible = false;
            this.dgvOperationsBox.Columns["Venta"].Visible = false;

        }

        /// <summary>
        /// Set Header Text display to User 
        /// </summary>
        private void setFieldsDetails()
        {
            this.dgvOperationsBox.Columns["Id"].HeaderText = "Operación No.";
            this.dgvOperationsBox.Columns["TypeOp"].HeaderText = "Tipo de Operación";
        }


        /// <summary>
        ///  Submit Request to get operations by Users (Admin, casher)
        /// </summary>
        private void getRequestOperation()
        {
            #region Uses Cases ...
            /*                  ------------------------------------- Uses Cases  -------------------------------------------------------
                    Case 1: lsprocess is null and lsuser is null ==> getOperations without to indicare user  dates (operations with current date by default)
                    case 2: lsprocess is null and lsuser is != null ==> getOperationsByUser but need to request dates (operations with current date by default)  ---> OK
                    case 3: lsprocess is != null and lsuser is != null ==> getOperations but need to request  dates 
                    case 4: lsprocess is != null and lsuser is null ==> getOperations but need to request dates                         
            */


            /*

            if (String.IsNullOrEmpty(this.cmbListProcess.Text) == true && String.IsNullOrEmpty(this.cmbListUsers.Text) == true || (this.cmbListUsers.Visible = false))
            {
                if (this.validatorRol() != false)
                    this.getOperationsByUserDate();
            }

            if (String.IsNullOrEmpty(this.cmbListProcess.Text) == true && String.IsNullOrEmpty(this.cmbListUsers.Text) == false && (this.cmbListUsers.Visible = true))
            {
                if (this.validatorRol() != true)
                    this.getOperationsByUserDateAdm();
            }

            if (String.IsNullOrEmpty(this.cmbListProcess.Text) == false && String.IsNullOrEmpty(this.cmbListUsers.Text) == false)
            {
                if (validatorRol() != true)
                    this.getOperationsByUserDateType();
            }

            if (String.IsNullOrEmpty(this.cmbListProcess.Text) == false && String.IsNullOrEmpty(this.cmbListUsers.Text) == true)
            {
                if (this.validatorRol() != true)
                    this.getOperationsByUser();
            }
            */
            #endregion

            if(string.IsNullOrEmpty(this.cmbListProcess.Text) == true)
            {
                this.getOperationsByUserDate();
            }

            if(string.IsNullOrEmpty(this.cmbListProcess.Text) == false)
            {
                this.getOperationsByUserDateType();
            }
        }

        /// <summary>
        ///  Load All Users
        /// </summary>
        private void LoadUsers()
        {
            try
            {
                this.cmbListUsers.DataSource = UsuariosBO.getAllUsers;
                this.cmbListUsers.DisplayMember = "User_name";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        ///  Load All Operation type in Box History
        /// </summary>
        private void LoadTypeOp()
        {
            try
            {
                this.cmbListProcess.DataSource = OperationsCajaBO.getListOpType;
                this.cmbListProcess.DisplayMember = "Type";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnFind_Click(object sender, EventArgs e)
        {
            this.getRequestOperation();
        }

        private void cmbListUsers_DropDown(object sender, EventArgs e)
        {
            this.LoadUsers();
        }

        private void cmbListProcess_DropDown(object sender, EventArgs e)
        {
            this.LoadTypeOp();
        }

        private void btnPrintTicket_Click(object sender, EventArgs e)
        {
            var q = new DialogResult();

            this.getOperationById();
            q = MessageBox.Show("Seguro desea imprimir de operación de la Caja. Verificar su selección antes de continuar", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if(q == DialogResult.Yes)
            {
                this.PrintTicketOp();
                MessageBox.Show("Ticket impreso.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.btnFind.Focus();
            }
        }
    }
}
