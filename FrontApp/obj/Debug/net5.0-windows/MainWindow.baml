   M S B A M L   `   `   `  ����C  ?FrontApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:FrontAppFrontApp  5   	       FrontApp.MainWindow   5   	   R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:FrontApp     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6%   
�������.+�5      �� -   5         ��Name$ SelectReadPath��5      $��20��6-   $?��9Выбрать файл для архивирования��69   $��Center=�6b   $��Center=�6   6�   5      �� 5   
   $��1��6   $��0��6%   
������.+�5      �� -   5        $ SelectSavePath��5      $��20��6-   $1��+Выбрать файл для записи��69   $��Center=�6[   $��Center=�6x   6�   5      �� 5   
   $��0��6   $��1��6%   
�������.+�5      �� -   5        $ 
ArchiveBtn��5      $��20��6)   $��Архивировать��65   $��Center=�6L   $��Center=�6i   6�   5      �� 5   
   $��1��6   $��1��6%   
������.+�5      �� -   5        $ UnzipBtn��5      $��20��6'   $$��Разархивировать��63   $��Center=�6M   $��Center=�6j   6�   5      5       5!      