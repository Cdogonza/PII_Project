using System;
using Telegram.Bot.Types;
namespace ClassLibrary
{ 

    public class UserState
    {
        private static UserState instance;
        public static UserState Instance
         {
            get
            {
                if (instance == null)
                {
                    instance = new UserState();
                }

                return instance;
            }
        }
        private UserState()
        {
        }


    }


















}