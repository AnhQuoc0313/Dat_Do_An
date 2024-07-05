using Dat_Do_An.Module.BusinessObjects;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Dat_Do_An.Module.Controllers
{
    [DefaultClassOptions]
    [ImageName("BO_Note")]
    [System.ComponentModel.DisplayName("Phiếu Chi")]
    [DefaultProperty("SoCT")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class PHIEUCHI : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public PHIEUCHI(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (Session.IsNewObject(this))
            {
                NgayCT = DateTime.Now;
            }
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        //private string _PersistentProperty;
        //[XafDisplayName("My display name"), ToolTip("My hint message")]
        //[ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(false)]
        //[Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)]
        //public string PersistentProperty {
        //    get { return _PersistentProperty; }
        //    set { SetPropertyValue(nameof(PersistentProperty), ref _PersistentProperty, value); }
        //}

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}
        private KHACHHANG _KHACHHANG;
        [Association("KEY_KHC")]
        [Size(50), XafDisplayName("Khách Hàng")]
        public KHACHHANG KHACHHANG
        {
            get { return _KHACHHANG; }
            set { SetPropertyValue<KHACHHANG>(nameof(KHACHHANG), ref _KHACHHANG, value); }
        }


        private string _SoCT;
        [Size(50), XafDisplayName("Số Chứng Từ")]
        public string SoCT
        {
            get { return _SoCT; }
            set { SetPropertyValue<string>(nameof(SoCT), ref _SoCT, value); }
        }


        private DateTime _NgayCT;
        [XafDisplayName("Ngày Chứng Từ")]
        [ModelDefault("EditMask", "dd/MM/yyyy HH:mm")]
        [ModelDefault("DisplayFormat", "{0: dd/MM/yyyy HH:mm}")]
        public DateTime NgayCT
        {
            get { return _NgayCT; }
            set { SetPropertyValue<DateTime>(nameof(NgayCT), ref _NgayCT, value); }
        }


        private decimal _Sotien;
        [XafDisplayName("Số Tiền")]
        [ModelDefault("DisplayFormat", "{0:n0} VND")]
        [ModelDefault("EditMask", "n0")]
        public decimal Sotien
        {
            get { return _Sotien; }
            set { SetPropertyValue<decimal>(nameof(Sotien), ref _Sotien, value); }
        }

        private NHANVIEN _NHANVIEN;
        [Association("KEY_NVC")]
        [Size(50), XafDisplayName("Nhân Viên")]
        public NHANVIEN NHANVIEN
        {
            get { return _NHANVIEN; }
            set { SetPropertyValue<NHANVIEN>(nameof(NHANVIEN), ref _NHANVIEN, value); }
        }
    


        private string _GhiChu;
        [Size(50), XafDisplayName("Ghi Chú")]
        public string GhiChu
        {
            get { return _GhiChu; }
            set { SetPropertyValue<string>(nameof(GhiChu), ref _GhiChu, value); }
        }

    }
}