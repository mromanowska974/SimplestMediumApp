   M S B A M L   `   `   `  ????G  CMyLoginPanel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MyLoginPanelMyLoginPanel  5          MyLoginPanel.RegisterPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:MyLoginPanel     5        N? Title$  RegisterPage??5	      .??5      ? 
??????? ? RowDefinitions 5   
   ?? 5      $??3* ?6   ?? 5      $??* ?6   ?? 5      $??3* ?6   ?? 5      $??* ?6   ?? 5      $??3* ?6   ?? 5      $??* ?6   ?? 5      $??3* ?6   ?? 5      $??* ?6   ?? 5      $??3* ?6   ?? 5      $??3* ?6   ?? 5      $??* ?6   ?? 5      $??3* ?6   ?? 5      $??* ?6   ?? 5      $??3* ?6   .+?5   
   (? $??0??6   .??5      ?  ? ColumnDefinitions 5      ?? 5       $??* ?6'   ?? 5!      $??* ?6'   .+?5#      ?? $??E-Mail??5$      $
??Left=?6*   $??Center=?5%      $??0 0 50 0q?5&      ?? 5(      -   5         ??Name$ 	txt_email??5(      $??Right=?5)       ?? TextWrapping$
 Wrap=?5*      $??Center=?62   $	??120??5+      $??1??6*   $??18??6:   5-      5.      (? 5/   
   $??1??6   .??50      ?? -   5         ??Name$ lb_emailError??50      $?? ??6+   $??Center=?51      $??Center=?65   $	??100(?52      
???  ??6(   54      (? 55   
   $??2??6   .??56      ?  57      ?? 58      $??* ?6'   ?? 59      $??* ?6'   .+?5;      ?? $??Login??6   $
??Left=?6(   $??Center=?5<      $??0??67   $??0 0 55 0q?5=      ?? 5?      -   5        $ 	txt_login??5?      $??Right=?5@      $
 Wrap=?6:   $??Center=?5A      $??1??69   $	??120??5B      $??18??6*   5D      5E      (? 5F   
   $??3??6   .??5G      ?? -   5        $ lb_loginError??5G      $?? ??6+   $??Center=?5H      $??Center=?65   $	??100(?5I      
???  ??6'   5K      (? 5L   
   $??4??6   .??5M      ?  5N      ?? 5O      $??* ?6'   ?? 5P      $??* ?6'   .+?5R      ?? $??Hasło??5S      $
??Left=?6)   $??Center=?5T      $??0??64   $??0 0 55 0q?5U      G? 5W      -   5         G?Name$ txt_password??5W      $??Right=?5X   "   $??Center=?5Y   "   $	??120??5Z   "    G? Password$  ??6.   $??1??5[   "   5]      5^      (? 5_   
   $??5??6   .??5`      ?? -   5        $ lb_passwordError??5`      $?? ??6.   $??Center=?5a      $??Center=?65   $	??100(?5b      
???  ??6'   5c      (? 5d   
   $??6??6   .??5e      ?  5f      ?? 5g      $??* ?6'   ?? 5h      $??* ?6'   .+?5k      ?? $??Powtórz hasło??5l      $
??Left=?61   $??Center=?5m      $??0??64   $??0 0 10 0q?5n      G? 5p      -   5        $ txt_repeatPassword??5p      $??Right=?5q   "   $??Center=?6>   $	??120??5r   "   $??1??6.   5t      5u      (? 5v   
   $??7??6   .??5w      ?? -   5        $ lb_repeatedError??5w      $?? ??6.   $??Center=?5x      $??Center=?65   $	??100(?5y      
???  ??6'   5{      (? 5|   
   $??8??6   .??5}      ?  5~      ?? 5      $??* ?6'   .+?5?      ?? $??Płeć??6   $
??Left=?6'   $??Center=?5?      $??	0 0 185 0q?67   5?      5?      (? 5?   
   $??9??6   .??5?      ? $	??300??6   $??10q?6    5?      ?? 5?      $??* ?6'   ?? 5?      $??* ?6'   ?? 5?      $??2* ?6'   .+?5?      	? -	   5         	?Name$ radio_female??5?      $??Kobieta??5?   "   $??Center=?64   $??Center=?5?   "   $??10(?6=   	 	? 	GroupName$	 genderRadio??5?   "   $??0??6:   	? 5?      -
   5        $ 
radio_male??5?      $??10(?62   $??Mężczyzna??5?   "   $??Center=?66   $??Center=?5?   "   $	 genderRadio??6=   $??1??5?   "   	? 5?      -   5        $ radio_other??5?      $??10(?63   $ ??Inne/Wolę nie odpowiadać??5?   "   $??Center=?5?   "   $??Center=?6?   $	 genderRadio??5?   "   $??2??6:   5?      5?      (? 5?   
   $??10??6   .??5?      ?? -   5        $ lb_genderError??5?      $?? ??6,   $??Center=?5?      $??Center=?65   $	??100(?5?      
???  ??6'   5?      (? 5?   
   $??11??6   .??5?      ?  5?      ?? 5?      $??* ?6'   ?? 5?      $??* ?6'   .+?5?      ?? $??Data urodzin??5?      $
??Left=?60   $??Center=?5?      $??0??64   $??0 0 30 0q?5?      (  "System.Windows.Controls.DatePicker  5?      -   5        
  Name$
 dp_birthday??5?      $??Right=?5?   !   $??Center=?6=   $??1??5?   !   5?      5?      (? 5?   
   $??12??6   .??5?      ?? -   5        $ lb_birthdayDateError??5?      $?? ??62   $??Center=?5?      $??Center=?65   $	??100(?5?      
???  ??6'   5?      (? 5?   
   $??13??6   .??5?      ?? -   5         ??Name$ btn_register??5?      $??Zarejestruj??5?      $??Center=?6/   $	??Top=?5?      61   5?      5?      5?      