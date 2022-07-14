
// Try - Catch --> hata yönetimi için kullanılır. Uygulamada bulunan hatalar direk kullanıcı karşısına çıkmasın diye uygulanır.

//FormatException
//Try-catch içerisinde olmadığı için kullanıcı FormatException çıktısını görecektir.
// var deneme = "test";
// int deneme2 = Convert.ToInt32(deneme);

// try{
//     var deneme = "test";
//     int deneme2 = Convert.ToInt32(deneme);
// }catch(Exception ex){
//     Console.WriteLine("Hata: "+ ex.ToString());
// }

try{
    var deneme = "test";
    int deneme2 = Convert.ToInt32(deneme);
}
//Hataya göre özelleştirme gerçekleştirdik. FormaatException yakalanırsa buraya girecektir. 
catch(FormatException ex){
     Console.WriteLine("Format Exception: "+ ex.ToString());
}
//Diğer tüm hatalar için bu bloğu kullanacak.
catch(Exception ex){
    Console.WriteLine("Hata: "+ ex.ToString());
}