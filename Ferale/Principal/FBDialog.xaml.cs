using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ferale.Principal
{
    /// <summary>
    /// Lógica de interacción para FBDialog.xaml
    /// </summary>
    public partial class FBDialog : Window
    {
        public ApiResults data = new ApiResults();

        public FBDialog()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            string returnURL = WebUtility.UrlEncode("https://www.facebook.com/connect/login_success.html");
            string scopes = WebUtility.UrlEncode("");
            FBwebBrowser.Source = new Uri(string.Format("https://www.facebook.com/dialog/oauth?client_id={0}&redirect_uri={1}&response_type=token%2Cgranted_scopes&scope={2}&display=popup", new object[] { Sesion.idAppFacebook, returnURL, scopes }));
            FBwebBrowser.Navigated += FBwebBrowser_Navigated;
        }

        private void FBwebBrowser_Navigated(object sender, NavigationEventArgs e)
        {
            // Check to see if we hit return url
            if (FBwebBrowser.Source.AbsolutePath == "/connect/login_success.html")
            {
                // Check for error
                if (FBwebBrowser.Source.Query.Contains("error"))
                {
                    // Error detected
                    data.ErrorFound = true;
                    ExtractURLInfo("?", FBwebBrowser.Source.Query);
                }
                else
                {
                    data.ErrorFound = false;
                    ExtractURLInfo("#", FBwebBrowser.Source.Fragment);
                }
                // Close the dialog
                this.Close();
            }
        }


        private void ExtractURLInfo(string inpTrimChar, string urlInfo)
        {
            string fragments = urlInfo.Trim(char.Parse(inpTrimChar)); // Trim the hash or the ? mark
            string[] parameters = fragments.Split(char.Parse("&")); // Split the url fragments / query string 

            // Extract info from url
            foreach (string parameter in parameters)
            {
                string[] name_value = parameter.Split(char.Parse("=")); // Split the input

                switch (name_value[0])
                {
                    case "access_token":
                        data.Accesstoken = name_value[1];
                        break;
                    case "expires_in":
                        double expires = 0;
                        if (double.TryParse(name_value[1], out expires))
                            data.Tokenexpires = DateTime.Now.AddSeconds(expires);
                        else
                            data.Tokenexpires = DateTime.Now;
                        break;
                    case "granted_scopes":
                        data.GrantedScopes = WebUtility.UrlDecode(name_value[1]);
                        break;
                    case "denied_scopes":
                        data.DeniedScopes = WebUtility.UrlDecode(name_value[1]);
                        break;
                    case "error":
                        data.Error = WebUtility.UrlDecode(name_value[1]);
                        break;
                    case "error_reason":
                        data.ErrorReason = WebUtility.UrlDecode(name_value[1]);
                        break;
                    case "error_description":
                        data.ErrorDescription = WebUtility.UrlDecode(name_value[1]);
                        break;
                    default:
                        break;
                }
            }
        }

        private void ClosingWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ((Login)(Owner)).SendArgumentsBack(data);
        }
    }
}
