
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace LoginSystem
{
    public class OnLogInEventArgs : EventArgs
    {
        private string mUser_Num_Email;
        private string mPassword;

        public string User_Num_Email
        {
            get { return mUser_Num_Email; }
            set { mUser_Num_Email = value; }
        }
        public string Password
        {
            get { return mPassword; }
            set { mPassword = value; }
        }
        public OnLogInEventArgs(string UserInfo, string password) : base()
        {
            User_Num_Email = UserInfo;
            Password = password;
        }

    }
    class dialog_LogIn : DialogFragment
    {
        private EditText mTxtUser_Num_Email;
        private EditText mTxtPassword;
        private Button mBtnLogIn;
        public event EventHandler<OnLogInEventArgs> mOnLogInComplete;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_log_in, container, false);

            mTxtUser_Num_Email = view.FindViewById<EditText>(Resource.Id.txtEmail);
            mTxtPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
            mBtnLogIn = view.FindViewById<Button>(Resource.Id.btnLogIn);
            mBtnLogIn.Click += mBtnLogIn_Click;;

            return view;
        }
        void mBtnLogIn_Click(object sender, EventArgs e)
        {
            //User has clicked the sign up button
            mOnLogInComplete.Invoke(this, new OnLogInEventArgs(mTxtUser_Num_Email.Text, mTxtPassword.Text));
            this.Dismiss();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle); //Sets the title bar to invisible
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation; //set the animation
        }
    }
}