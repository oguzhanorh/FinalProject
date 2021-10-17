using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime ="Sistem bakımda";
        public static string ProductsListed =" Ürünler listelendi";
        public static string ProductCountOfCategoryError = "Bir Kategoride en fazla 10 ürün olabilir";
        public static string ProductNameAlreadyExists = "Bu isimde zaten başka bir ürün mevcut";
        internal static string CategoryLimitExceded = "Kategoriler 15 ile sınırlıdır..";
        internal static string AuthorizationDenied="Yetkiniz yok.";
        internal static string UserRegistered="Kayıt oldu.";
        internal static string UserNotFound="Kullanıcı bulunamadı.";
        internal static string PasswordError="Parola Hatası.";
        internal static string SuccessfulLogin="Başarılır giriş";
        internal static string UserAlreadyExists="Böyle bir kullanıcı var.";
        internal static string AccessTokenCreated="Token oluşturuldu.";
    }
}
