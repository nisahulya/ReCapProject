using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        
        public static string DailyPriceInvalid = "Günlük ücret geçersiz";
       
        public static string CarUpdated = "Araba güncellendi";

        public static string CarDeleted = "Araba silindi";

        public static string BrandNameInvalid = "Marka ismi geçersiz";

        public static string BrandAdded = "Marka eklendi";

        public static string BrandUpdated = "Marka güncellendi";

        public static string BrandDeleted = "Marka silindi";

        public static string ColorNameInvalid = "Renk ismi geçersiz";

        public static string ColorAdded = "Renk eklendi";

        public static string ColorUpdated = "Renk güncellendi";

        public static string ColorDeleted = "Renk silindi";

        public static string MaintanceTime = "Bakım Zamanı";

        public static string CarsListed = "Arabalar Listelendi";

        public static string CarGottenByBrandId = "Araba marka id'sine göre getirildi";

        public static string CarGottenByColorId = "Araba renk id'sine göre getirildi";

        public static string CarDetailsGotten = "Araba detayları getirildi";

        public static string CarGottenById = "Araba getirildi";

        public static string BrandsListed = "Markalar Listelendi";

        public static string BrandGottenById = "Marka getirildi";

        public static string ColorsListed = "Renkler Listelendi";

        public static string ColorGottenById = "Renk getirildi";

        public static string UserAdded = "Kullanıcı eklendi";

        public static string UserUpdated = "Kullanıcı güncellendi";

        public static string UserDeleted = "Kullanıcı silindi";

        public static string UsersListed = "Kullanıcılar Listelendi";

        public static string UserGottenById = "Kullanıcı getirildi";

        public static string RentalAdded = "Kiralama eklendi";

        public static string RentalUpdated = "Kiralama güncellendi";

        public static string RentalDeleted = "Kiralama silindi";

        public static string RentalsListed = "Kiralamalar listelendi";

        public static string RentalGottenById = "Kiralama getirildi";

        public static string CustomerAdded = "Müşteri eklendi";

        public static string CustomerUpdated = "Müşteri güncellendi";

        public static string CustomerDeleted = "Müşteri silindi";

        public static string CustomersListed = "Müşteriler listelendi";

        public static string CustomerGottenByUserId = "Müşteri kullanıcı id'sine göre getirildi";

        public static string NotReturned = "Araba Teslim edilmedi";

        public static string CarImagesListed = "Araba resimleri listelendi";

        public static string ExceedCarImagesNumber = "Araba resimleri sayısı 5'i aştı";

        public static string WrongFileType = "Yanlış dosya tipi";

        public static string CarImageAdded = "Araba resmi eklendi";

        public static string NotExistFile = "Dosya bulunamadı";

        public static string CarImagesGottenById = "Araba resmi id'ye göre getirilidi";

        public static string NotFoundCarImage = "Araba resmi bulunamadı";

        public static string CarImageUpdated = "Araba resmi güncellendi";
        public static string DeletedCarImage = "Araba resmi başarıyla silindi";
        public static string AuthorizationDenied = "Yetkiniz Yok";
        public static string ClaimsGotten = "Claimler Getirildi";
        public static string UserGottenByMail = "Kullanıcı mailine göre getirilidi";
        public static string UserRegistered ="Kayıt Oldu";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError ="Parola Hatası";
        public static string SuccessfulLogin = "Başarılı Giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Access token oluşturuldu";
        public static string RentalDetailsGotten = "Kiralama detayları getirildi";

        public static string CreditCardNumberAllreadyExists = "Kredi Kartı Numarası Mevcut";
        public static string CartPaymentsUpdated = "Kredi Kartı Numarası ile Ödeme işlemi Güncellendi";
        public static string CartPaymentsDeleted = "Kredi Kartı Numarası ile Ödeme işlemi Silindi";
        public static string CartPaymentsAdded = "Kredi Kartı Numarası ile Ödeme işlemi Eklendi";
        public static string GetCartPaymentsByCustomerIdListed = "Kredi Kartı Numarası ile Ödeme işlemi Müşteri Numarasına Göre Listelendi";
        public static string CartPaymentsListed = "Kredi Kartı Numarası ile Ödeme işlemleri Listelendi";

        public static string NotEnoughFindeks = "Findeks Puanınız bu aracı kiralamak için yeterli değil";
        public static string Added = "Eklendi";
        public static string Deleted = "Silindi";
        public static string DeletedByCarId = "Car Id'ye göre Silindi";
        public static string NotExist = "Yok";
        public static string Updated = "Güncellendi";
        public static string AlreadyExist = "Zaten Var";
    }
}
