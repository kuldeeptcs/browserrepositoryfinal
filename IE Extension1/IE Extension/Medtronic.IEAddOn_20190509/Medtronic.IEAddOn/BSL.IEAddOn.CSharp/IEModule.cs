using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows.Forms;
using IE = Interop.SHDocVw;
using AddinExpress.IE;

namespace Medtronic_IEAddOn
{
    /// <summary>
    /// Add-in Express for Internet Explorer Module
    /// </summary>
    [ComVisible(true), Guid("0377DDB2-A279-4BF3-A58E-4A85464991D2")]
    public class IEModule : AddinExpress.IE.ADXIEModule
    {
        public string URLPath = string.Empty;
        public IEModule()
        {
            InitializeComponent();
            //Please write any initialization code in the OnConnect event handler

           // MessageBox.Show("Hii");
        }

        private ADXIECommandItem IE11CommandItem;

        public IEModule(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            //Please write any initialization code in the OnConnect event handler
        }

        #region Component Designer generated code
        /// <summary>
        /// Required by designer
        /// </summary>
        private System.ComponentModel.IContainer components;

        /// <summary>
        /// Required by designer support - do not modify
        /// the following method
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.IE11CommandItem = new AddinExpress.IE.ADXIECommandItem(this.components);
            // 
            // IE11CommandItem
            // 
            this.IE11CommandItem.ActiveIcon = "Icons.Chat_48";
            this.IE11CommandItem.Caption = "Medtronic Feedback Extension";
            this.IE11CommandItem.CommandGuid = "{D729A016-23AD-402E-8C6D-4B343F1E9806}";
            this.IE11CommandItem.OnClick += new AddinExpress.IE.ADXIECommandClick_EventHandler(this.IE11CommandItem_OnClick);
            // 
            // IEModule
            // 
            this.Commands.Add(this.IE11CommandItem);
            this.HandleShortcuts = true;
            this.LoadInMainProcess = false;
            this.ModuleName = "Medtronic_IEAddOn";

        }
        #endregion

        #region ADX automatic code

        // Required by Add-in Express - do not modify
        // the methods within this region

        public override System.ComponentModel.IContainer GetContainer()
        {
            if (components == null)
                components = new System.ComponentModel.Container();
            return components;
        }

        [ComRegisterFunctionAttribute]
        public static void RegisterIEModule(Type t)
        {
            AddinExpress.IE.ADXIEModule.RegisterIEModuleInternal(t);
        }

        [ComUnregisterFunctionAttribute]
        public static void UnregisterIEModule(Type t)
        {
            AddinExpress.IE.ADXIEModule.UnregisterIEModuleInternal(t);
        }

        [ComVisible(true)]
        public class IECustomContextMenuCommands :
            AddinExpress.IE.ADXIEModule.ADXIEContextMenuCommandDispatcher
        {
        }

        [ComVisible(true)]
        public class IECustomCommands :
            AddinExpress.IE.ADXIEModule.ADXIECommandDispatcher
        {
        }

        #endregion

        public IE.WebBrowser IEApp
        {
            get
            {
                return (this.IEObj as IE.WebBrowser);
            }
        }

        public mshtml.HTMLDocument HTMLDocument
        {
            get
            {
                return (this.HTMLDocumentObj as mshtml.HTMLDocument);
            }
        }
        private void IEModule_OnError(ADXIEErrorEventArgs e)
        {
            //TODO: We can implement the error logging
        }

        private void IE11CommandItem_OnClick(object sender, object htmlDoc)
        {

           // MessageBox.Show("Hii");
            if (!HTMLDocument.url.ToString().Contains("medtronic"))
            {
                MessageBox.Show(Constants.RestrictionMessage);
            }
            else
            {
                SmileyPopup smileyPopup = new SmileyPopup(HTMLDocument.url);
                smileyPopup.Show();
            }
        }
    }
}