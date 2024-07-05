using Dat_Do_An.Module.Controllers;
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

namespace Dat_Do_An.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Customer")]
    [System.ComponentModel.DisplayName("Đơn Hàng")]
    [DefaultProperty("MaDH")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class DONHANG : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public DONHANG(Session session)
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

        private string _MaDH;
        [Size(50), XafDisplayName("Mã Đơn Hàng")]
        [RuleRequiredField("DONHANG", DefaultContexts.Save, "MSP khong duoc de trong")]
        [RuleUniqueValue, Indexed(Unique = true)]
        public string MaDH
        {
            get { return _MaDH; }
            set { SetPropertyValue<string>(nameof(MaDH), ref _MaDH, value); }
        }


        private string _TrangThai;
        [Size(50), XafDisplayName("Trạng Thái Đơn Hàng")]
        public string TrangThai
        {
            get { return _TrangThai; }
            set { SetPropertyValue<string>(nameof(TrangThai), ref _TrangThai, value); }
        }

        private string _GhiChuDH;
        [Size(50), XafDisplayName("Ghi Chú Đơn Hàng")]
        public string GhiChuDH
        {
            get { return _GhiChuDH; }
            set { SetPropertyValue<string>(nameof(GhiChuDH), ref _GhiChuDH, value); }
        }
        private DateTime _ThoiGian;
        [XafDisplayName("Thời Gian Giao")]
        [ModelDefault("EditMask", " HH:mm dd/MM/yyyy ")]
        [ModelDefault("DisplayFormat", "{0: HH:mm dd/MM/yyyy}")]
        public DateTime ThoiGian
        {
            get { return _ThoiGian; }
            set { SetPropertyValue<DateTime>(nameof(ThoiGian), ref _ThoiGian, value); }
        }
        private SANPHAM _SANPHAM;
        [Association("KEY_DHSP")]
        [Size(50), XafDisplayName("Sản phẩm")]
        public SANPHAM SANPHAM
        {
            get { return _SANPHAM; }
            set { SetPropertyValue<SANPHAM>(nameof(SANPHAM), ref _SANPHAM, value); }
        }

        private KHACHHANG _KHACHHANG;
        [Association("KEY_DHKH")]
        [Size(50), XafDisplayName("Khách hàng")]
        public KHACHHANG KHACHHANG
        {
            get { return _KHACHHANG; }
            set { SetPropertyValue<KHACHHANG>(nameof(KHACHHANG), ref _KHACHHANG, value); }

        }
    }
}