   M S B A M L   `   `   `  ����D  @Ostermelo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Ostermelo	Ostermelo  5   	       Ostermelo.DeliveryWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Ostermelo     5   	     � Title$#  Kiszállítások rögzítése��5   	   $	��250��6)   $	��400��66   $��16(�6B    � 
ResizeMode$ NoResize=�6P   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��auto �6   �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   $��Partner:��6   $��Center=�60   �� 5   
   $��1��6   $��Gyümölcslé:��6   $��Center=�63   �� 5   
   $��2��6   $��Dátum:��6   $��Center=�6.   �� 5   
   $��3��6   $��Kartonok száma:��6   $��Center=�67   �� 5   
   -   5        $��
cboPartner��5      $��0��6%   $��1��62   $��28��6B    �� SelectedValue 5      �� *	PartnerId+�� 5   
   -   5        $��cboJuice��5      $��1��6#   $��1��60   $��28��6@    5      �� *	JuiceId+(  "System.Windows.Controls.DatePicker  5   
   -   5        $��dpDate��5      $��2��6#   $��1��60   $��28��6@   $	��130��6L   $
��Left=�6X      SelectedDate 5       �� *
BindedDate+�� 5!   
   -   5        $��txtPack��5!      $��3��6!   $��1��6.   $��28��6>   $��60��6J   $
��Left=�6U   ��5"      �� *Pack+� 5$   
   $��4��6   $��2��6!   $��Center=�65   $��Center=�6R   .+�5%      �� -   5        $��Mentés��5%      $	��100��6&   $��28��62   $��0 0 10 0q�6>   6P   �� 5&      -   5        $��Mégsem��5&      $	��100��6&   $��28��62   $��10 0 0 0q�6>   6P   5'      5(      5)      