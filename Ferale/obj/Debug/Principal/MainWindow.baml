   M S B A M L   `   `   `  ����A  =Ferale, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:FeraleFerale  5   	       Ferale.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Ferale     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   -   5          � Title$  
MainWindow��5   	   $	��450��5
   	   $	��800��6    � WindowStartupLocation$ CenterScreen=�6"    � WindowState$ 	Maximized=�6G    � WindowStyle$
 None=�6_   .��5      � ��5   
   �� 5       �� ImageSource$, &/Ferale;component/img/fondo_vivero.jpg��6    �� Opacity$	 0.9Q�6N    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��250 �6   �� 5      $��* �6   .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone     
GreenBrush#��[  6#     
WhiteBrush#��[ 6L   $��1��6u   $��1��6�   $��Stretch=�6�   $��45��6�   .��5      � .+�5      '  !MaterialDesignThemes.Wpf.PopupBox     PlacementMode$ BottomAndAlignRightEdges=�6*   $��Right=�6S   $��10q�6o   �� 5      -   5        	 ��Name$	 Close��5      $��50��6(   $��443,10,49,4q�63   $��Right=�6H   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]
   Kind$
 Close=�6.   5      �� 5       -   5        $	 Minimize��5       $��50��6+   $��388,10,104,4q�66   $��Right=�6L   .��5!        $
 WindowMinimize=�6.   5"      �� 5#      -   5         ��Name$ 
lblUsuario��5#      $��Usuario Desconocido��6,   $
��Left=�6J   $��	10,10,0,0q�6e   $	��Top=�6x   $	��250��6�   $��28��6�   6�   5$      5%      � 5&   
   $��Stretch=�6   $��1��6-     PrimaryHueMidBrush#��[ 6;    5'      �� 5(      $	��160 �6    �� 5)      $
��200* �6    .+�5+      � $��0��6     YellowBrush#��[ 6    .+�5,      A� $	��150��6   $	��150��6'   $��Center=�63   $��Center=�6N   ��5-      �� 5.      $ ../img/logoHoja.jpg��6&    j� Stretch$
 Fill=�6I   50      51      �� 52      $��Stretch=�6   $��Disabled=�69   $
��Auto=�6b   $��1��6�   #��[  6�     	TitleFont#��[ 6�   .��53      �� -   5         ��Name$
 Menu��53      $��10q�6+   54      55      �� 56   
   -   5        $ StackPanelMain��56      $��1��6-   $��Center=�6:   $��1��6W   $��50 50 50 30q�6g   �� 57   
   -   5        $ 
StackPanel��57      $��1��6)   $��1��66   $��Stretch=�6F   $��0,51,0,0q�6d   $��Bottom=�6v   .+�58      � $	��411��6    J� RenderTransformOrigin$ 0.5,0.5&�6    59      5:      5;      