   M S B A M L   `   `   `  ����A  =Ferale, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:Ferale.Controles.Limpiezas.VentanasPlaga(Ferale.Controles.Limpiezas.VentanasPlaga  5   	   :    4Ferale.Controles.Limpiezas.VentanasPlaga.EditarPlaga   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Hlocal6clr-namespace:Ferale.Controles.Limpiezas.VentanasPlaga     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	   -   5          � Title$  EditarPlaga��5   	   $��830.384��5	   	   $��555.793��6    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�62      
GreenBrush#��[  5   	   $��4q�63   .��5      � .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  #��[  6#     
WhiteBrush#��[ 6L   $��1��6u   $��1��6�   $��Stretch=�6�   .��5      � .+�5      �� -   5         ��Name$ Close��5      $��50��6(   $��	0,10,10,4q�63   $��Right=�6F   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Close=�6.   5      5      5      �� 5   
   $��MODIFICAR PLAGA��6   $��
101,49,0,0q�6*   $	��Top=�6>   $��62��6V   $��36(�6b    J� RenderTransformOrigin$ -0.52,0.898&�6p   $
��Left=�6�   $	��332��6�   #  MaterialDesignThemes.Wpf.Card  5   
   $��
54,111,0,0q�6   $
��Left=�62   $	��433��6M   $	��Top=�6Y   $	��640��6q   .��5      � $��0,0,10,0q�6   .+�5        -   5          Name$ cardGuardar��5   &   $��42��6;     	BlueBrush#��[ 6G   #��[ 6o   $��
88,487,0,0q�6�   $
��Left=�6�   $	��226��6�   .��5      �� $��18(�6    #��[ 6.   $��GUARDAR��6W   $��Right=�6f   $��Center=�6�   $��	0,10,73,8q�6�   5        5      -   5        $ cardCancelar��5   &   $��42��6<   #��[ 6H   #��[ 6p   $��
88,555,0,0q�6�   $
��Left=�6�   $	��226��6�   .��5      �� $��18(�6    #��[ 6.   $��CANCELAR��6W   $��Center=�6g   $��Center=�6�   5       (  "System.Windows.Controls.DatePicker  5!      -   5          Name$ dpFechaLimpieza��5!      $
��Left=�66   $��	53,25,0,0q�6Q   $	��Top=�6d   $��38��6|   $	��303��6�   )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Fecha Limpieza��6�   �� 5"      -   5        
 ��Name$
 cbxEstablecimiento��5"      $
��Left=�67   $��	53,96,0,0q�6R   $	��Top=�6e   $	��303��6}   $��39��6�   �� 5#      -   5        $
 cbxTipoLimpieza��5#      $
��Left=�64   $��
53,170,0,0q�6O   $	��Top=�6c   $	��303��6{   $��39��6�   �� 5$      -   5         ��Name$ txtDescripcionPlaga��5$      $
��Left=�67   $��44��6R   $��
53,242,0,0q�6^    �� TextWrapping$
 Wrap=�6r   $	 Descripción Plaga��6�   $	��Top=�6�   $	��303��6�   �� 5%      -	   5        $ txtTratamiento��5%      $
��Left=�62   $��44��6M   $��
53,326,0,0q�6Y   $
 Wrap=�6m   $	 Tratamiento Aplicado��6�   $	��Top=�6�   $	��303��6�   �� 5&      -
   5        $
 cbxEmpleado��5&      $
��Left=�60   $��
53,407,0,0q�6K   $	��Top=�6_   $	��303��6w   $��39��6�   5(      5)      5*      5+      