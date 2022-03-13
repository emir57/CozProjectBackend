using System;
using System.Collections.Generic;
using System.Text;

namespace CozProjectBackend.Business.Constants
{
    public class TurkishLanguage : ILanguage
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
    }
}
