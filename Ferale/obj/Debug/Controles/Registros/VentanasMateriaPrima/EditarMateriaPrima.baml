   M S B A M L   `   `   `  ����A  =Ferale, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:Ferale.Controles.Registros.VentanasMateriaPrima/Ferale.Controles.Registros.VentanasMateriaPrima  5   	   H    BFerale.Controles.Registros.VentanasMateriaPrima.EditarMateriaPrima   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Olocal=clr-namespace:Ferale.Controles.Registros.VentanasMateriaPrima     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   -   5          � Title$  EditarMateriaPrima��5   	   $��733.591��6$   $��555.793��65    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�62      
GreenBrush#��[  5   	   $��4q�63   .��5      � .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  #��[  6#     
WhiteBrush#��[ 6L   $��1��6u   $��1��6�   $��Stretch=�6�   .��5      � .+�5      �� -   5         ��Name$ Close��5      $��50��6(   $��	0,10,10,4q�63   $��Right=�6F   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Close=�6.   5      5      5      �� 5   
   $��MODIFICAR MATERIA��6   $��	87,49,0,0q�6,   $	��Top=�6?   $��62��6W   $��36(�6c    J� RenderTransformOrigin$ -0.52,0.898&�6q   $
��Left=�6�   $	��360��6�   #  MaterialDesignThemes.Wpf.Card  5   
   $��
54,111,0,0q�6   $
��Left=�62   $	��433��6M   $	��Top=�6Y   $	��561��6q   .��5      � $��0,0,10,0q�6   .+�5        -   5          Name$ cardGuardar��5   &   $��42��6;     	BlueBrush#��[ 6G   #��[ 6o   $��102,424,0,0q�6�   $
��Left=�6�   $	��226��6�   .��5      �� $��18(�6    #��[ 6.   $��GUARDAR��6W   $��Right=�6f   $��Center=�6�   $��	0,10,73,8q�6�   5        5      -   5        $ cardCancelar��5   &   $��42��6<   #��[ 6H   #��[ 6p   $��102,492,0,0q�6�   $
��Left=�6�   $	��226��6�   .��5      �� $��18(�6    #��[ 6.   $��CANCELAR��6W   $��Center=�6g   $��Center=�6�   5      �� 5       -   5         ��Name$ txtNombreMateria��5       $��0��65   $��0��6B    % !MaterialDesignFloatingHintTextBox#��[ 6R   $	��Top=�6�   )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Razon Social��6�   $��	53,30,0,0q�6�   $��16(�6�   $
��Left=�6�   $	��303��6  �� 5!      -   5        $ txtStock��5!      $��0��6-   $��0��6:   #��[ 6J   $	��Top=�6�   $		 Nit��6�   $��	53,90,0,0q�6�   $��16(�6�   $
��Left=�6�   $	��303��6�   �� 5"      -   5        $ txtCantidadMinima��5"      $��0��66   $��0��6C   #��[ 6S   $	��Top=�6�   $		 Nit��6�   $��
53,158,0,0q�6�   $��16(�6�   $
��Left=�6�   $	��303��6  �� 5#      -   5        $ txtUnidadMedida��5#      $��0��64   $��0��6A   #��[ 6Q   $	��Top=�6�   $		 Nit��6�   $��
53,294,0,0q�6�   $��16(�6�   $
��Left=�6�   $	��303��6  �� 5$      -	   5        
 ��Name$
 cbxAlamacen��5$      $
��Left=�60   $��
53,359,0,0q�6K   $	��Top=�6_   $	��303��6w   $��40��6�   (  "System.Windows.Controls.DatePicker  5%      -
   5          Name$ dateUltimoDiaReposicion��5%      $
��Left=�6>   $��
53,233,0,0q�6Y   $	��Top=�6m   $��44��6�   $	��303��6�   $	 Ultimo Dia Reposicion��6�   5'      5(      5)      5*      