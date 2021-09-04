# AloneMan
Güney Kore Günlükleri

Http response hatasi aldığımda database connection'ı tekrardan check etmem gerekiyor. Çünkü yeniden sign olmam gerekebilir bunu araştıracağım.

Http intercepter  kullanılarak her http requestinde loading gif oynatabiliyoruz. Service içersinde sadece bir loading değişkeni tutup buna subscribe olunup true ya da false değerine göre ngIf ile componentini çağırıyoruz router-outlet altında.