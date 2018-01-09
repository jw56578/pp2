using System;
namespace pp2.ViewModels
{
    public class LoginViewModel: BaseViewModel
    {
        // The information needs to be Properties, not fields, else binding won't work

        string tn;
        public string TenancyName { get { return tn; } set{
               SetProperty(ref tn, value);
            } }

        string uea;
        public string UsernameOrEmailAddress{ get { return uea; } set{SetProperty(ref uea, value);}}
        string p;
        public string Password{ get { return p; } set { SetProperty(ref p, value); } }
        bool r;
        public bool RememberMe{ get { return r; } set { SetProperty(ref r, value); } }
        string ru;
        public string ReturnUrl{ get { return ru; } set { SetProperty(ref ru, value); } }
        string message;
        public string Message { get { return message; } set { SetProperty(ref message, value); } }




        public LoginViewModel()
        {
        }
    }
}
