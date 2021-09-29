# Problems
Http response hatasi aldığımda database connection'ı tekrardan check etmem gerekiyor. Çünkü yeniden sign olmam gerekebilir bunu araştıracağım.

Http intercepter  kullanılarak her http requestinde loading gif oynatabiliyoruz. Service içersinde sadece bir loading değişkeni tutup buna subscribe olunup true ya da false değerine göre ngIf ile componentini çağırıyoruz router-outlet altında.



# **To Do**

1-) Kullanici adi kücük ya da büyük girildiğinde büyük ihtimal database'de karsilastirma yaparken toLower kullanıldıgı icin kücük ya da büyük fark etmiyor bu problem çözülmeli fark etmeli.

2-) 2 tane admin kullanicisi olusturuldu yapılan işlerde CreateUser farklı olacağından hangi User tarafından yapıldiğini bilmek icin

3-) Yazilmasi gereken tüm yerlere try catch yazilacak ya da if ile kontrol edilecek hatayi görmek lazım :)
