Project Name: JumpCore Prototype  
Developer: [Şebnem Gündüz]  
Engine Version: Unity 2023.2.20f1  
Submission for: Welfish Studio - Jumping Mechanic Case  
E-posta: [sebnemgunduz0@gmail.com]  
Tarih: [15.07.2025]  

-----------------------------  
General Overview:  
Bu prototip, Doodle Jump tarzında dikey ilerlemeli bir yapıda, tek tuşla hem zıplama hem de yatay hareket içeren bir oyun olarak geliştirildi.  
Amacımız, zıplama mekaniklerinin hem mekanik hem de görsel olarak tatmin edici hissettirmesini sağlamak.  

-----------------------------  
Included Core Features:  
✔ Tek Tuşla Kontrol: Oyuncu yalnızca tek bir tuş (space tuşu veya ekran dokunuşu) ile karakterin zıplamasını ve yön değiştirmesini sağlar.  
✔ Hareketli Karakter: Karakter, her zıplamada sağa-sola dönüşümlü olarak hareket eder. Bu da platformlar arası geçişi sağlar.  
✔ Platform Yapısı: Başlangıçta 3 platform bulunmakla birlikte, tüm platformlar rastgele ve prosedürel olarak üretilir.  
✔ Düşme = Game Over: Oyuncu bir platformu ıskalayıp ekran dışına düşerse, oyun sona erer.  
✔ Zıplama Hissi: Zıplama hem fiziksel tepkiler hem de görsel-işitsel detaylarla desteklenmiştir.  

-----------------------------  
Mechanical Polish:  
✔ Procedural Platform Generation: Platformlar yukarı doğru, belirli aralıklarla ve rastgele x konumlarında oluşturulur.  
✔ Coyote Time: Oyuncu platformdan ayrıldıktan sonra kısa süreliğine (yaklaşık 0.5 sn) zıplayabilir.  
✔ Dynamic Gravity: Zıplarken düşük, düşerken yüksek yerçekimi uygulanarak doğal bir zıplama eğrisi oluşturulmuştur.  

-----------------------------  
Game Feel ("Juice"):  
Aşağıdaki görsel ve işitsel geribildirimler uygulanmıştır:  
✔ Ses Efektleri: Zıplama ve iniş sırasında ses efektleri çalınır.  
✔ Particle Effect: Zıplama ve yere iniş sırasında küçük toz bulutları görünür.  
✔ Squash & Stretch: Zıplama öncesi karakter hafifçe basık hale gelir, zıplarken uzar ve inişte tekrar sıkışır.  
✔ Input Feedback: Zıplama öncesinde karakter hafifçe gerilerek kullanıcıya “hazır ol” hissi verir.  
