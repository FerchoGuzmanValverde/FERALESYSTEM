   M S B A M L   `   `   `  ����d  `Microsoft.Maps.MapControl.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPFMicrosoft.Maps.MapControl.WPF  5   	   A =Ferale, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:Ferale.Controles.Registros.VentanasMateriaPrima/Ferale.Controles.Registros.VentanasMateriaPrima 5   	   C   =Ferale.Controles.Registros.VentanasMateriaPrima.EditarAlmacen   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   `mRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPF     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Olocal=clr-namespace:Ferale.Controles.Registros.VentanasMateriaPrima     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	   -   5          � Title$  EditarAlmacen��5	   	   $��713.427��6   $��483.422��60    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�62      
GreenBrush#��[  5   	   $��4q�63   .��5      � .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  #��[  6#     
WhiteBrush#��[ 6L   $��1��6u   $��1��6�   $��Stretch=�6�   .��5      � .+�5      �� -   5         ��Name$ Close��5      $��50��6(   $��	0,10,10,4q�63   $��Right=�6F   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Close=�6.   5      5      5      �� 5   
   $��MODIFICAR ALMACEN��6   $��	47,49,0,0q�6,   $	��Top=�6?   $��62��6W   $��36(�6c   $
��Left=�6q   $	��369��6�   #  MaterialDesignThemes.Wpf.Card  5   
   -   5          Name$ cardInsertar��5      $��58��64     	BlueBrush#��[ 6@   #��[ 6h   $��
37,244,0,0q�6�   $
��Left=�6�   $	��184��6�   .��5      �� $��18(�6   #��[ 6&   $��GUARDAR��6O   $��Center=�6^   $��Center=�6{   5        5   
   -   5        $ 
cardEditar��5      $��58��62   #��[ 6>   #��[ 6f   $��242,244,0,0q�6�   $
��Left=�6�   $	��184��6�   .��5      �� $��18(�6   #��[ 6&   $��CANCELAR��6O   $��Center=�6_   $��Center=�6|   5      �� 5   
   -   5         ��Name$ 
txtAlmacen��5      $��0��6&   $��0��63    % !MaterialDesignFloatingHintTextBox#��[ 6C   $	��Top=�6~   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ NombreAlmacen��6�   $��
37,116,0,0q�6�   $��16(�6�   $
��Left=�6�   $	��389��6  '   !Microsoft.Maps.MapControl.WPF.Map  5   
   -   5        	  Name$	 mapaAlmacen��5      +   %Microsoft.Maps.MapControl.WPF.MapCore
   	ZoomLevel$
 16Q�6%      Center<   6Microsoft.Maps.MapControl.WPF.Design.LocationConverter$ -17.915842, -64.527463 64      CredentialsProviderT	   NMicrosoft.Maps.MapControl.WPF.Design.ApplicationIdCredentialsProviderConverter$F @Ahz4AmC6aICIiw0CA0SwwJS9Y6k2snf_FN-HGh1eP5zF33qyeucr93bQ-hgs0-4e	 6T      Mode;
   5Microsoft.Maps.MapControl.WPF.Design.MapModeConverter$ AerialWithLabels
 6�   $��37,333,49.2,67.6q�6�   6�     5    
   -   5        $ cardSaltelite��5       $��39��65   #��[ 6A   #��[ 6i   $��
37,643,0,0q�6�   $
��Left=�6�   $��86��6�   .��5!      �� $��18(�6   #��[ 6&   $��Satelite��6O   $��Center=�6_   $��Center=�6|   5"        5#   
   -   5        $ 	cardCalle��5#      $��39��61   #��[ 6=   #��[ 6e   $��138,643,0,0q�6�   $
��Left=�6�   $��86��6�   .��5$      �� $��18(�6   #��[ 6&   $��Calle��6O   $��Center=�6\   $��Center=�6y   5%        5&   
   -	   5        $ cardAcercar��5&      $��39��63   #��[ 6?   #��[ 6g   $��238,643,0,0q�6�   $
��Left=�6�   $��86��6�   .��5'      �� $��18(�6   #��[ 6&   $��Acercar��6O   $��Center=�6^   $��Center=�6{   5(        5)   
   -
   5        $ 
cardAlejar��5)      $��39��62   #��[ 6>   #��[ 6f   $��340,643,0,0q�6�   $
��Left=�6�   $��86��6�   .��5*      �� $��18(�6   #��[ 6&   $��Alejar��6O   $��Center=�6]   $��Center=�6z   5+      �� 5,   
   -   5        $ txtDireccion��5,      $��0��6(   $��0��65   #��[ 6E   $	��Top=�6�   $ 
Dirección��6�   $��
37,175,0,0q�6�   $��16(�6�   $
��Left=�6�   $	��389��6   5-      5.      