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
    [NavigationItem(false)]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class DONGNHAP : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public DONGNHAP(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
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

        private SANPHAM _SANPHAM;
        [Association("KEY_SPDN")]
        public SANPHAM SANPHAM
        {
            get { return _SANPHAM; }
            set { SetPropertyValue<SANPHAM>(nameof(SANPHAM), ref _SANPHAM, value); }
        }


        private PHIEUNHAP _PHIEUNHAP;
        [Association("KEY_DONGPN")]
        public PHIEUNHAP PHIEUNHAP
        {
            get { return _PHIEUNHAP; }
            set { SetPropertyValue<PHIEUNHAP>(nameof(PHIEUNHAP), ref _PHIEUNHAP, value); }
        }



        private double _SoLuong;
        [XafDisplayName("So Luong Nhap")]
        public double SoLuong
        {
            get { return _SoLuong; }
            set { SetPropertyValue<double>(nameof(SoLuong), ref _SoLuong, value); }
        }

        private decimal _DonGia;
        [XafDisplayName("Don Gia")]
        public decimal DonGia
        {
            get { return _DonGia; }
            set { SetPropertyValue<decimal>(nameof(DonGia), ref _DonGia, value); }
        }

        private double _Vat;
        [XafDisplayName("Thue Vat")]
        public double Vat
        {
            get { return _Vat; }
            set { SetPropertyValue<double>(nameof(Vat), ref _Vat, value); }
        }


        private double _ChietKhau;
        [XafDisplayName("Chiet Khau")]
        public double ChietKhau
        {
            get { return _ChietKhau; }
            set { SetPropertyValue<double>(nameof(ChietKhau), ref _ChietKhau, value); }
        }
    }
}