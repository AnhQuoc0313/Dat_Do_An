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
    [NavigationItem(true)]
    [System.ComponentModel.DisplayName("Dòng Nhập")]
    [ImageName("BO_Country_v92")]
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
        [Size(50), XafDisplayName("Đồ Ăn")]
        public SANPHAM SANPHAM
        {
            get { return _SANPHAM; }
            set { SetPropertyValue<SANPHAM>(nameof(SANPHAM), ref _SANPHAM, value); }
        }


        private PHIEUNHAP _PHIEUNHAP;
        [Association("KEY_DONGPN")]
        [Size(50), XafDisplayName("Phiếu Nhập")]
        public PHIEUNHAP PHIEUNHAP
        {
            get { return _PHIEUNHAP; }
            set { SetPropertyValue<PHIEUNHAP>(nameof(PHIEUNHAP), ref _PHIEUNHAP, value); }
        }



        private double _SoLuong;
        [XafDisplayName("Số lượng nhập")]
        public double SoLuong
        {
            get { return _SoLuong; }
            set { 
                   bool isModified = SetPropertyValue<double>(nameof(SoLuong), ref _SoLuong, value); 
                if(!IsLoading && !IsDeleted && !IsSaving) { Tinhtong(); }
                }
        }

        private decimal _DonGia;
        [XafDisplayName("Đơn giá")]
        [ModelDefault("DisplayFormat", "{0:n0} VND")]
        [ModelDefault("EditMask", "n0")]
        public decimal DonGia
        {
            get { return _DonGia; }
            set {
                bool isModified = SetPropertyValue<decimal>(nameof(DonGia), ref _DonGia, value);
                if (!IsLoading && !IsDeleted && !IsSaving) { Tinhtong(); }
            }
        }
        private decimal _Thanhtien;
        [XafDisplayName("Thành tiền"),ModelDefault("AllowEdit","false")]
        [ModelDefault("DisplayFormat", "{0:n0} VND")]
        [ModelDefault("EditMask", "n0")]
        public decimal Thanhtien
        {
            get { return _Thanhtien; }
            set { SetPropertyValue<decimal>(nameof(Thanhtien), ref _Thanhtien, value); }
        }
        private void Tinhtong()
        {
            decimal tong = 0;
            tong = (decimal)SoLuong * DonGia;
            Thanhtien = tong;
        }

             
    }
}