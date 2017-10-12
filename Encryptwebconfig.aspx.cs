using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Configuration;

public partial class Encryptwebconfig : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void cmdEncrypt_Click(object sender, EventArgs e)
    {
        String username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        Configuration config = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
        ConfigurationSection section = config.GetSection(txtSectionName.Text);
        if (section == null)
        {
            lblMessage.Text = "Section name does not exist.";
        }
        else if (!section.SectionInformation.IsProtected)
        {
            section.SectionInformation.ProtectSection("RsaProtectedConfigurationProvider");
            config.Save();
            lblMessage.Text = "Section is encrypted.";
        }
    }

    protected void cmdDecrypt_Click(object sender, EventArgs e)
    {
        Configuration config = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
        ConfigurationSection section = config.GetSection(txtSectionName.Text);
        if (section == null)
        {
            lblMessage.Text = "Section name does not exist.";
        }
        else if (section.SectionInformation.IsProtected)
        {
            section.SectionInformation.UnprotectSection();
            config.Save();
            lblMessage.Text = "Section is decrypted.";
        }
    }
}
