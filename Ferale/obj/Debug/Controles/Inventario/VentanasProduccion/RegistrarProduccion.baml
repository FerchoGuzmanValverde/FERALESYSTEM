   M S B A M L   `   `   `  ����A  =Ferale, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullo<clr-namespace:Ferale.Controles.Inventario.VentanasProduccion.Ferale.Controles.Inventario.VentanasProduccion  5   	   H    BFerale.Controles.Inventario.VentanasProduccion.RegistrarProduccion   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Nlocal<clr-namespace:Ferale.Controles.Inventario.VentanasProduccion     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	   -   5          � Title$  RegistrarProduccion��5	   	   $��795.744��6%   $��1058.993��66    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�62      
GreenBrush#��[  5   	   $��4q�63   .��5      � .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  #��[  6#     
WhiteBrush#��[ 6L   $��1��6u   $��1��6�   $��Stretch=�6�   .��5      � .+�5      �� -   5         ��Name$ Close��5      $��50��6(   $��
991,10,0,4q�63   $
��Left=�6G   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Close=�6.   5      5      5      #  MaterialDesignThemes.Wpf.Card  5   
   $��557,196,0,0q�6   $
��Left=�63   $	��411��6N   $	��Top=�6Z   $	��485��6r   .��5      � $��0,0,10,0q�6   .+�5      �� -   5         ��Name$ txtCantidadProducto��5      $��0��68   $��0��6E    % !MaterialDesignFloatingHintTextBox#��[ 6U   $	��Top=�6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Cantidad Producida��6�   $��
53,187,0,0q�6�   $��16(�6�   $
��Left=�6�   $	��315��6  �� 5      -   5         ��Name$ cbxTipoProducto��5      $
��Left=�64   $��	53,35,0,0q�6O   $	��Top=�6b   $	��315��6z   $��46��6�   $ Estado Entrega��6�   	   
IsFloating	 . 6�   �� 5      -   5        $ cbxProducto��5      $
��Left=�60   $��
53,101,0,0q�6K   $	��Top=�6_   $	��315��6w   $��46��6�   $ Producto��6�   	 . 6�   (  "System.Windows.Controls.DatePicker  5      -   5        
  Name$
 dtpFechaVencimiento��5      $
��Left=�6:   $��
53,273,0,0q�6U   $	��Top=�6i   $��42��6�   $	��315��6�   5      5        5    
   -   5          Name$ cardGuardar��5       $��51��63     	BlueBrush#��[ 6?   #��[ 6g   $��772,708,0,0q�6�   $
��Left=�6�   $	��196��6�   .��5!      �� $��18(�6   #��[ 6&   $��GUARDAR��6O   $	��Top=�6^   $��	0,14,49,0q�6v   $��Right=�6�   $��89��6�   5"        5#   
   -   5        $ cardCancelar��5#      $��52��64   #��[ 6@   #��[ 6h   $��557,707,0,0q�6�   $
��Left=�6�   $	��202��6�   .��5$      �� $��18(�6   #��[ 6&   $��CANCELAR��6O   $��Center=�6_   $��Center=�6|   5%        5&   
   $��
57,196,0,0q�6   $
��Left=�62   $	��433��6M   $	��Top=�6Y   $	��575��6q   .��5'      � $
��Left=�6   $	��555��6.   $��	10,10,0,0q�6;   $	��Top=�6N   $	��413��6f   .+�5(      �� -	   5        $ txtCantidadMateria��5(      $��0��67   $��0��6D   #��[ 6T   $	��Top=�6�   $# Cantidad de materia utilizada��6�   $��	22,40,0,0q�6�   $��16(�6�   $
��Left=�6  $	��303��6"    5)      -
   5        $ btnEditarDetalleVenta��5)   &   $��46��6E   $��355,74,10,0q�6Q   #��[ 6f   #��[ 6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   .��5*      �� .+�5+        $
 Edit=�62   $��45��6>   $��	0,0,0,-18q�6J   $��48��6]   #��[ 6h   5,      5-        5.      -   5        $ btnAgregarDetalleVenta��5.   &   $��46��6F   $��355,10,10,0q�6R   #��[ 6g   #��[ 6�   $ 0.5,0.5&�6�   .��5/      �� .+�50        $	 Add=�62   $��45��6=   $��	0,0,0,-18q�6I   $��48��6\   #��[ 6g   51      52        53      -   5        $ cardDeleteItem��53   &   $��46��6>   $��355,140,10,0q�6J   #��[ 6`   #��[ 6�   $ 0.5,0.5&�6�   .��54      �� .+�55        $ Delete=�62   $��45��6@   $��	0,0,0,-18q�6L   $��48��6_   #��[ 6j   56      57      �� 58      $��DETALLE MATERIA PRIMA��6   $
��Left=�6:   $	��334��6U   $��
10,211,0,0q�6b   $	��Top=�6v   $	��393��6�   .��59      �� -   5         ��Name$ lstDetalleMateria��59      $	��281��69   $	��Top=�6F   $	��377��6^   6j   5:      �� 5;      -   5        $ cbxMateriaPrima��5;      $
��Left=�64   $��
22,114,0,0q�6O   $	��Top=�6c   $	��303��6{   $��46��6�   $ Materia Prima��6�   	 . 5<      5=      5>      �� 5?   
   $��PRODUCTO��6   $��Right=�6#   $��0,139,83.2,0q�6?   $	��Top=�6U   $��52��6m   $	��411��6y   $��25(�6�   $��Center=�6�   $��Center=�6�   $
��Bold)�6�   �� 5@   
   $��MATERIA PRIMA��6   $��Right=�6(   $��0,139,561.2,0q�6D   $	��Top=�6[   $��52��6s   $	��433��6   $��25(�6�   $��Center=�6�   $��Center=�6�   $
��Bold)�6�   �� 5A   
   $��NUEVA PRODUCCIÓN��6   $��
337,66,0,0q�6+   $	��Top=�6?   $��62��6W   $��36(�6c   $ -0.52,0.898&�6q   $
��Left=�6�   $	��368��6�   5B      5C      