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
    [ImageName("Travel_ReceptionBell")]
    [System.ComponentModel.DisplayName("Đồ Ăn")]
    [DefaultProperty("TenSP")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class SANPHAM : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public SANPHAM(Session session)
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

        private DANHMUC _DANHMUC;
        [Association("KEY_SP")]
        [Size(50), XafDisplayName("Danh Mục")]
        public DANHMUC DANHMUC
        {
            get { return _DANHMUC; }
            set { SetPropertyValue(nameof(DANHMUC), ref _DANHMUC, value); }
        }

        [Delayed(true), VisibleInListView(true)]
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PopupPictureEdit,
    DetailViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorFixedHeight = 340, DetailViewImageEditorFixedWidth = 227,
    ListViewImageEditorCustomHeight = 40)]
        [XafDisplayName("Ảnh")]
        public byte[] AnhSP
        {
            get { return GetDelayedPropertyValue<byte[]>(nameof(AnhSP)); }
            set { SetDelayedPropertyValue(nameof(AnhSP), value); }
        }


        private string _MaSP;
        [Size(50), XafDisplayName("Mã Món")]
        [RuleRequiredField("SANPHAM", DefaultContexts.Save, "MSP khong duoc de trong")]
        [RuleUniqueValue, Indexed(Unique = true)]
        public string MaSP
        {
            get { return _MaSP; }
            set { SetPropertyValue<string>(nameof(MaSP), ref _MaSP, value); }
        }



        private string _TenSP;
        [Size(50), XafDisplayName("Tên Món")]
        public string TenSP
        {
            get { return _TenSP; }
            set { SetPropertyValue<string>(nameof(TenSP), ref _TenSP, value); }
        }



        private decimal _GiaSP;
        [XafDisplayName("Giá Món")]
        [ModelDefault("DisplayFormat", "{0:n0} VND")]
        [ModelDefault("EditMask", "n0")]
        public decimal GiaSP
        {
            get { return _GiaSP; }
            set { SetPropertyValue<decimal>(nameof(GiaSP), ref _GiaSP, value); }
        }


        private int _SoLuong;
        [XafDisplayName("Số Lượng Món")]
        public int SoLuong
        {
            get { return _SoLuong; }
            set { SetPropertyValue<int>(nameof(SoLuong), ref _SoLuong, value); }
        }


        private string _MieuTaSP;
        [Size(50), XafDisplayName("Miêu Tả Món")]
        public string MieuTaSP
        {
            get { return _MieuTaSP; }
            set { SetPropertyValue<string>(nameof(MieuTaSP), ref _MieuTaSP, value); }
        }


        [DevExpress.Xpo.Aggregated, Association("KEY_SPDN")]
        public XPCollection<DONGNHAP> _DONGNHAP
        {
            get { return GetCollection<DONGNHAP>(nameof(_DONGNHAP)); }
        }

        [DevExpress.Xpo.Aggregated, Association("KEY_SPDX")]
        public XPCollection<DONGXUAT> _DONGXUAT
        {
            get { return GetCollection<DONGXUAT>(nameof(_DONGXUAT)); }
        }


    }
}