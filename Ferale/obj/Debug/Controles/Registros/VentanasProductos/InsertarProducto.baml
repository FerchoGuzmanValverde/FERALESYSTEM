   M S B A M L   `   `   `  ����A  =Ferale, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:Ferale.Controles.Registros.VentanasProductos,Ferale.Controles.Registros.VentanasProductos  5   	   C    =Ferale.Controles.Registros.VentanasProductos.InsertarProducto   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Llocal:clr-namespace:Ferale.Controles.Registros.VentanasProductos     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   -   5          � Title$  InsertarProducto��5   	   $��784.037��6"   $��998.329��63    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�62      
GreenBrush#��[  5   	   $��4q�63   .��5      � .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  #��[  6#     
WhiteBrush#��[ 6L   $��1��6u   $��1��6�   $��Stretch=�6�   .��5      � .+�5      �� -   5         ��Name$ Close��5      $��50��6(   $��	0,10,10,4q�63   $��Right=�6F   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Close=�6.   5      5      5      �� 5   
   $��NUEVO PRODUCTO��6   $��
355,49,0,0q�6)   $	��Top=�6=   $��62��6U   $��36(�6a    J� RenderTransformOrigin$ -0.52,0.898&�6o   $
��Left=�6�   $	��323��6�   #  MaterialDesignThemes.Wpf.Card  5   
   $��
54,111,0,0q�6   $
��Left=�62   $	��433��6M   $	��Top=�6Y   $	��530��6q   .��5      � $��0,0,10,0q�6   .+�5      �� -   5         ��Name$ txtDescripionProducto��5      $��0��6:   $��0��6G    % !MaterialDesignFloatingHintTextBox#��[ 6W   $	��Top=�6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Descripcion Producto��6�   $��	53,30,0,0q�6�   $��16(�6�   $
��Left=�6  $	��303��6  �� 5      -   5        $ txtPrecioBase��5      $��0��62   $��0��6?   #��[ 6O   $	��Top=�6�   $ Precio Base��6�   $��	53,90,0,0q�6�   $��16(�6�   $
��Left=�6�   $	��303��6  �� 5      -   5        $ txtIndicaciones��5      $��0��64   $��0��6A   #��[ 6Q   $	��Top=�6�   $ Indicaciones��6�   $��
53,155,0,0q�6�   $��16(�6�   $
��Left=�6�   $	��303��6  �� 5      -   5        $ txtVariedad��5      $��0��60   $��0��6=   #��[ 6M   $	��Top=�6�   $ Variedad��6�   $��
53,224,0,0q�6�   $��16(�6�   $
��Left=�6�   $	��303��6  �� 5      -   5        	 ��Name$	 cbxTipoProducto��5      $
��Left=�64   $��
53,315,0,0q�6O   $	��Top=�6c   $	��303��6{   $��46��6�   �� 5      -   5        $ txtStock��5      $��0��6-   $��0��6:   #��[ 6J   $	��Top=�6�   $ Stock��6�   $��
53,402,0,0q�6�   $��16(�6�   $
��Left=�6�   $	��303��6  $��46��6  5!      5"        5#   
   -	   5        
  Name$
 cardGuardar��5#      $��42��63     	BlueBrush#��[ 6?   #��[ 6g   $��261,689,0,0q�6�   $
��Left=�6�   $	��226��6�   .��5$      �� $��18(�6   #��[ 6&   $��GUARDAR��6O   $��Right=�6^   $��Center=�6z   $��	0,10,73,8q�6�   5%        5&   
   -
   5        $
 cardCancelar��5&      $��42��64   #��[ 6@   #��[ 6h   $��516,690,0,0q�6�   $
��Left=�6�   $	��226��6�   .��5'      �� $��18(�6   #��[ 6&   $��CANCELAR��6O   $��Center=�6_   $��Center=�6|   5(        5)   
   $��516,111,0,0q�6   $
��Left=�63   $	��433��6N   $	��Top=�6Z   $	��530��6r   .��5*      � $
��Left=�6   $	��510��6.   $��	10,10,0,0q�6;   $	��Top=�6N   $	��413��6f   .+�5+      �� -   5         ��Name$ groupBox��5+      $��IMAGEN DEL PRODUCTO��6-   $
��Left=�6J   $��	10,10,0,0q�6e   $	��Top=�6x   $	��420��6�   $	��393��6�   .��5,      �� -   5         ��Name$ imgProducto��5,      $	��352��61   $	��Top=�6>   $	��353��6V   5-        5.      -   5        $
 cardSelectImage��5.   &   $��42��6?   #��[ 6K   #��[ 6s   $��
95,458,0,0q�6�   $
��Left=�6�   $	��226��6�   .��5/      �� $��18(�6    #��[ 6.   $��SELECCIONAR IMAGEN��6W   $��Center=�6q   $��Center=�6�   50      51      52      53      54      