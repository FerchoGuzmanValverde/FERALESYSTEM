   M S B A M L   `   `   `  ����A  =Ferale, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Ferale.Controles.InventarioFerale.Controles.Inventario  5      1    +Ferale.Controles.Inventario.ControlIngresos   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:Ferale.Controles.Inventario     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $	��706��5	      $	��961��6   $��Roboto)�6'   .��5
      � .+�5   
   �   � ColumnDefinitions  5      �� 5      $	��250 �6#   �� 5      $��2* �6#   �� 5      $
��1.5* �6#   .+�5      � $��0��6   $��2��6#   $��10,10,240,-10q�67    � RowDefinitions 5      �� 5      $
��0.7* �6$   �� 5      $��3* �6$   �� 5      $��1* �6$   .+�5      �� 
�������$��1q�61   $��282,104,-394,0q�6E    �� CornerRadius$ 5��6]   $��Stretch=�6n   $
��Auto��6�    J� RenderTransformOrigin$ 0.805,0.493&�6�   $��2��6�   z�5      V� 5      .~�5      �� �� 5       �� AngleY$
 0.23Q�6,   �� 5      T� 5       T� Y$ 1.604Q�61   5       ._�5"      �� $��0,0,-1,0q�6   $��Disabled=�61   ���	#FFEFEC49.@�5#      �� .��5$      � $	��400��6#     5%   "   �� 5&   &   $��8* �67   �� 5'   &   $	��33* �67   �� 5(   &   $��7* �67   �� 5)   &   $	��32* �67   �� 5*   &   $��0* �67   .+�5,   "   '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ FormatListNumbered=�6:   $��Center=�6T   $��Center=�6o   $��	12,6,12,5q�6�   �� 5-   "   $��1��6-   $��Center=�6=   $��5q�6X   $��17��6c   .+�5.   &   �� $��Material��60   
�������$��14(�6R   5/   #   �� 50   "   $��2��6,   $��	Proveedor��6<   
�������$��Center=�6_   $��5,6,10,5q�6z   $��2��6�   $��16��6�   �� 51   "   $��4��6,   $��Fecha Ingreso��6<   
�������$��Center=�6c   $��5,6,-107,-8q�6~   $��29��6�   52      53      54      55      �� 56      $��FILTRAR POR:��6   $
��Left=�61   $	��451��6L   $��10,0,0,0q�6Y   $	��Top=�6k   $	��264��6�   $��1��6�   ���	#FFFDFDFD���	#FFBDBDA6.��57      � $��	0,10,0,-3q�6   $	��242��6.   .+�58      �� $��0��6"   $��0��6/    %  !MaterialDesignFloatingHintTextBox#��[  6?   $	��Top=�6z   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Material��6�   $��	0,12,10,0q�6�   �� 59      $��0��6"   $��0��6/   #��[  6?   $	��Top=�6z   $ 	Proveedor��6�   $��	0,70,10,0q�6�   �� 5:      ���	#FFEF3E1F$��BUSCAR��68   $��118,345,10,10q�6I   $
��Auto��6`   $
��Auto��6m   ���	#FFF03D1F6{   5;      5<      5>      �� 5?      ���	#FFEF3E1F$��	REGISTRAR��6,   $��167,207,10,448q�6@   $
��Auto��6X   $
��Auto��6e   $��2��6s   ���	#FFF03D1F6�   �� 5@      ���	#FFEF3E1F$��EDITAR��6,   $��167,283,10,372q�6=   $
��Auto��6U   $
��Auto��6b   $��2��6p   ���	#FFF03D1F6�   �� 5A      ���	#FFEF3E1F$	��VER��6,   $��167,359,10,296q�6:   $
��Auto��6R   $
��Auto��6_   $��2��6m   ���	#FFF03D1F6}   �� 5B      ���	#FFEF3E1F$��ELIMINAR��6,   $��167,435,10,216q�6?   $
��Auto��6W   $
��Auto��6d   $��2��6r   ���	#FFF03D1F6�   �� 5C      ���	#FFEF3E1F$��IR A REPORTES��6,   $��138,605,31,44q�6D   $
��Auto��6[   $
��Auto��6h   $��2��6v   ���	#FFF03D1F6�   �� 5D      $+��%GESTIÓN DE INGRESOS DE MATERIA PRIMA��6   $
��Left=�6C   $��
134,32,0,0q�6^   $	��Top=�6r   $��62��6�   $	��708��6�   $��3��6�   $��36(�6�   5E      5F      5G      