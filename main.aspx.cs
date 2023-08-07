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
    public partial class main : System.Web.UI.Page
    {
        MemberModel memberModel = new MemberModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = memberModel.GetMemberDetails();
            if (!IsPostBack)
            {
                //DataTable dt = ds.Tables[0];
                //ddlGender.DataSource = dt;
                //ddlGender.Items.Clear();
                //ddlGender.DataTextField = "GENDER_NAME";
                //ddlGender.DataValueField = "GENDER_ID";
                //ddlGender.DataBind();
               // ddlGender.Items.Insert(0, new ListItem("---Please Select gender--"));
                bindGrid();
            }
        }
        public void bindGrid()
        {
            DataSet ds = memberModel.GetMemberDetails();
            DataTable dtGV = ds.Tables[0];
            GV.DataSource= dtGV;
            GV.DataBind();
        }

        protected void submit_Click(object sender, EventArgs e)
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

        protected void GV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ErrorMsg.Text = string.Empty;
            SuccessMsg.Text = string.Empty;
            int c_id = Convert.ToInt32(GV.DataKeys[e.RowIndex].Values[0]);

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

        protected void GV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //DataSet ds = new DataSet();
            //ds = curdOperation.GetMemberDetails();
            //Da taTable dt = ds.Tables[0];
            //ddlGender.DataSource = dt;
            //ddlGender.Items.Clear();
            //ddlGender.DataTextField = "GENDER_NAME";
            //ddlGender.DataValueField = "GENDER_ID";
            //ddlGender.DataBind();
            //ddlGender.Items.Insert(0, new ListItem("---Please Select gender--"));
            //Gv.EditIndex = e.NewEditIndex;
            //bindGrid();

        }

        protected void GV_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //SuccessMsg.Text = string.Empty;
            //ErrorMsg.Text = string.Empty;
            //int c_id = Convert.ToInt32(Gv.DataKeys[e.RowIndex].Values[0]);

            //TextBox name = Gv.Rows[e.RowIndex].FindControl("txtGvName") as TextBox;
            //TextBox pNum = Gv.Rows[e.RowIndex].FindControl("txtGvPhnNo") as TextBox;
            //TextBox gender = Gv.Rows[e.RowIndex].FindControl("txtGender") as TextBox;
            //TextBox addr = Gv.Rows[e.RowIndex].FindControl("txtGvAddress") as TextBox;

            //bool isSaved = curdOperation.AddMember(name.Text, pNum.Text, gender.Text, addr.Text, "", "", 0, c_id);
            //if (isSaved)
            //{
            //    SuccessMsg.Text = "Member Updated";
            //    Gv.EditIndex = -1;
            //    bindGrid();
            //    //Response.Redirect("CurdOperation.aspx");
            //}
            //else
            //{
            //    ErrorMsg.Text = "Something Went Wrong";
            //}

        }
    }
}