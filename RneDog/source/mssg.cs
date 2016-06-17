using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RneDog
{
    public class mssg
    {
        public static void MessageTrue(string mtela, string messtrue, Page page)
        {
            try
            {
                Panel findMessage = (Panel)page.Master.FindControl("panel_message");
                Label findlbTela = (Label)page.Master.FindControl("lbTela");
                Label findlbMessage = (Label)page.Master.FindControl("lbMessage");

                findlbTela.Text = mtela;

                findMessage.CssClass = "panel-message panel-message-true";
                findlbMessage.Text = messtrue;

            }
            catch (Exception)
            {
            }
        }

        public static void MessageFalse(string mtela, string messfalse, Page page, string css = "panel-message-false")
        {
            try
            {
                Panel findMessage = (Panel)page.Master.FindControl("panel_message");
                Label findlbTela = (Label)page.Master.FindControl("lbTela");
                Label findlbMessage = (Label)page.Master.FindControl("lbMessage");

                findlbTela.Text = mtela;

                findMessage.CssClass = "panel-message " + css;
                findlbMessage.Text = messfalse;

            }
            catch (Exception)
            {
            }
        }

        public static void Close(Page page)
        {
            try
            {
                Panel findMessage = (Panel)page.Master.FindControl("panel_message");
                Label findlbTela = (Label)page.Master.FindControl("lbTela");
                Label findlbMessage = (Label)page.Master.FindControl("lbMessage");

                findlbTela.Text = "";
                findlbMessage.Text = "";
                findlbMessage.Text = "";
            }
            catch (Exception)
            {
            }
        }
    }
}