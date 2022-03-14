using Core.Utilities.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Message.Turkish
{
    public class TurkishLanguageMessage : ILanguage
    {
        public string SuccessAdd => "Ekleme Başarılı";

        public string SuccessDelete => "Silme Başarılı";

        public string SuccessUpdate => "Güncelleme Başarılı";

        public string FailureAdd => "Ekleme Başarısız";

        public string FailureUpdate => "Güncelleme Başarısız";

        public string FailureDelete => "Silme Başarısız";

        public string SuccessGet => "Listeleme Başarılı";

        public string FailureGet => "Listeleme Başarısız";

        public string UnAuthorize => "Yetkisiz İşlem";

        public string UserNotFound => "Kullanıcı Bulunamadı";

        public string RoleNotFound => "Rol Bulunamadı";

        public string SuccessCreateToken => "Token Oluşturma Başarılı";

        public string PasswordIsWrong => "Şifre Yanlış";

        public string LoginSuccess => "Giriş Başarılı";

        public string UserAlreadyExists => "Böyle Bir Kullanıcı Zaten Var";

        public string FailureRegister => "Kayıt Olunurken Bir Hata Meydana Geldi";
        public string SuccessRegister => "Başarıyla Kayıt Olundu";
    }
}
