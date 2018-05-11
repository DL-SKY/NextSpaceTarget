/*
© Alexander Danilovsky, 2018
----------------------------
= Event Manager =
*/

using System;

namespace DllSky.Managers
{
    public static class EventManager
    {
        #region Delegates
        public delegate void OnDefault();

        public delegate void OnChangeLanguage();
        public delegate void OnApplyLanguage();

        public delegate void OnStartPlayerTurn();
        public delegate void OnEndPlayerTurn();
        #endregion

        #region Actions
        public static event OnDefault eventOnDefault;

        public static event OnChangeLanguage eventOnChangeLanguage;
        public static event OnApplyLanguage eventOnApplyLanguage;

        public static event OnStartPlayerTurn eventOnStartPlayerTurn;
        public static event OnEndPlayerTurn eventOnEndPlayerTurn;
        #endregion

        #region Public methods
        public static void CallOnDefault()
        {
            if (eventOnDefault != null)
                eventOnDefault.Invoke();
        }

        public static void CallOnChangeLanguage()
        {
            if (eventOnChangeLanguage != null)
                eventOnChangeLanguage.Invoke();
        }

        public static void CallOnApplyLanguage()
        {
            if (eventOnApplyLanguage != null)
                eventOnApplyLanguage.Invoke();
        }

        public static void CallOnStartPlayerTurn()
        {
            if (eventOnStartPlayerTurn != null)
                eventOnStartPlayerTurn.Invoke();
        }

        public static void CallOnEndPlayerTurn()
        {
            if (eventOnEndPlayerTurn != null)
                eventOnEndPlayerTurn.Invoke();
        }
        #endregion
    }
}