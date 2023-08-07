using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GTech_MachineTest
{
    public partial class CurdWebForm : System.Web.UI.Page
    {
        MemberModel memberModel = new MemberModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = memberModel.GetMemberDetails();
            ErrorMsg.Text = string.Empty;
            SuccessMsg.Text = string.Empty;
            //RequiredFieldValidator1.Text = string.Empty;
            if (!IsPostBack)
            {
                DataTable dt = ds.Tables[0];
                ddlGender.DataSource = dt;
                ddlGender.Items.Clear();
                ddlGender.DataTextField = "GENDER_NAME";
                ddlGender.DataValueField = "GENDER_ID";
                ddlGender.DataBind();
                ddlGender.Items.Insert(0, new ListItem("---Please Select gender--"));
                bindGrid();

                
            }

        }

        public void bindGrid()
        {
            DataSet ds = memberModel.GetMemberDetails();
            DataTable dtGV = ds.Tables[1];
            GridShow.DataSource = dtGV;
            GridShow.DataBind();
        }

        protected void GridShow_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            ErrorMsg.Text = string.Empty;
            SuccessMsg.Text = string.Empty;
            int c_id = Convert.ToInt32(GridShow.DataKeys[e.RowIndex].Values[0]);

            bool isSaved = memberModel.AddMember("", "", "", "", "", "", 1, c_id);

            if (isSaved)
            {
                ErrorMsg.Text = "Member Deleted ";
                bindGrid();
            }
            else
            {
                ErrorMsg.Text = "Something Went Wrong";
            }
        }

        protected void GridShow_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridShow.EditIndex = -1;
            bindGrid();

        }

        protected void GridShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridShow_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DataSet ds = new DataSet();
            ds = memberModel.GetMemberDetails();
            DataTable dt = ds.Tables[0];
            ddlGender.DataSource = dt;
            ddlGender.Items.Clear();
            ddlGender.DataTextField = "GENDER_NAME";
            ddlGender.DataValueField = "GENDER_ID";
            ddlGender.DataBind();
            ddlGender.Items.Insert(0, new ListItem("---Please Select gender--"));
            GridShow.EditIndex = e.NewEditIndex;
            bindGrid();

        }

        protected void GridShow_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SuccessMsg.Text = string.Empty;
            ErrorMsg.Text = string.Empty;
            int c_id = Convert.ToInt32(GridShow.DataKeys[e.RowIndex].Values[0]);

            TextBox name = GridShow.Rows[e.RowIndex].FindControl("txtGvName") as TextBox;
            TextBox pNum = GridShow.Rows[e.RowIndex].FindControl("txtGvPhnNo") as TextBox;
            DropDownList ddlGender = GridShow.Rows[e.RowIndex].FindControl("ddlGender") as DropDownList;
            string selectedGender = string.Empty;
            if (ddlGender != null)
            {
                selectedGender = ddlGender.SelectedItem.Text;
               
            }
            TextBox addr = GridShow.Rows[e.RowIndex].FindControl("txtGvAddress") as TextBox;

            bool isSaved = memberModel.AddMember(name.Text, pNum.Text, selectedGender , addr.Text, "", "", 0, c_id);
            if (isSaved)
            {
                SuccessMsg.Text = "Member Updated";
                GridShow.EditIndex = -1;
                bindGrid();
            }
            else
            {
                ErrorMsg.Text = "Something Went Wrong";
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string photo = string.Empty;
            string photoPath = string.Empty;

            string name = txtName.Text;
            string phNum = txtPhNum.Text;
            string gender = ddlGender.SelectedItem.Text;
            string address = txtAddress.Text;


            if (FileUpload1.HasFile)
            {
                photo = Path.GetFileName(FileUpload1.PostedFile.FileName);
                photoPath = "~/Images/" + photo;
                FileUpload1.PostedFile.SaveAs(Server.MapPath(photoPath));
            }

            bool isSaved = memberModel.AddMember(name, phNum, gender, address, photo, photoPath);
            if (isSaved)
            {
                SuccessMsg.Text = "Member Added Successfully";
                bindGrid();
            }
            else
            {
                ErrorMsg.Text = "Something Went Wrong";
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            txtPhNum.Text = string.Empty;
            txtAddress.Text = string.Empty;
            ddlGender.SelectedIndex = 0;
            SuccessMsg.Text = string.Empty;
            ErrorMsg.Text = string.Empty;
            //RequiredFieldValidator1.Text = string.Empty;
        }
    }
}