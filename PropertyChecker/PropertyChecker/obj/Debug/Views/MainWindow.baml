   M S B A M L   `   `   `  ����J  FPropertyChecker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:PropertyCheckerPropertyChecker  5   	        PropertyChecker.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   X TXceed.Wpf.Toolkit, Version=3.1.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   )localclr-namespace:PropertyChecker  5   	     � Title$  Property Checker!��5	   	   $	��700��6#   $
��1000��60   
���   �.��5
      � 
���   � � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��2��6    $��0��64   
���   �
��� � �$��Property Checker��6g   $��Center=�6�   $
��Left=�6�   �� 5   
   -   5        $��OpenFolderDialog��5   B   $��0��6   $��2��6!   $��1��65   
���   �
��� � �$��Stretch=�6�   ��6�   Z� ��6�   �� *OpenFolderDialogContent.Value+ �� Mode$ OneWay=���6�   �� *OpenFolderDialogCommand+�� 5   
   -   5        $��LabelFolderName��5   -   $��0��6   $��2��6    
���   �
��� � �$��Center=�6j   ��6�   �� *LabelFolderName.Value+�� 5   
   -   5        $��TargetFolder��5   /   $��1��6   $��2��6"   
���   �
��� � �$��Stretch=�6j   $��Center=�6�   ��6�   Z� ��6�   �� *TargetFolderContent.Value+$ TwoWay=� �� 
IsReadOnly 6�   �� *#!TargetFolderContentReadOnly.Value+�� 5   
   -   5        $��CheckProperty��5   B   $��0��6   $��2��6!   $��3��65   
���   �
��� � �$��Stretch=�6   ��6�   Z� ��6�   �� *CheckPropertyContent.Value+$ OneWay=���6�   �� *CheckPropertyCommand+�� 5   
   -   5        $��Clear��5   B   $��0��6   $��2��6!   $��4��65   
���   �
��� � �$��Stretch=�6w   ��6�   Z� ��6�   �� *ClearContent.Value+$ OneWay=���6�   �� *ClearCommand+�� 5   
   -   5        $��DateTimeLabel��5   -   $��0��6   $��5��6    
���   �
��� � �$��Center=�6i   ��6�   �� *LabelDateTimeContent.Value+�� 5!   
   -   5        $��DeleteProperty��5!   B   $��0��6   $��2��6!   $��6��65   
���   �
��� � �$��Stretch=�6   ��6�   Z� ��6�   �� *DeletePropertyContent.Value+��6�   �� *DeletePropertyCommand+&   System.Windows.Controls.DataGrid  5"   
   -   5        $��ResultsDataGrid��5"   D   $��0��6   $��2��6#   $��7��67   
���   �   AutoGenerateColumns .     RowBackground
 �   �   HeadersVisibility$ Column=�6�      VerticalGridLinesBrush
 �����	   HorizontalGridLinesBrush
	 �����$��Stretch=�6�   
���   �
   SelectionUnit$
 FullRow=�6-  ��6E  �� *Results.Value+ �� SelectedItem 6k  ��  �� Path$ SelectedItemValue�   ColumnHeaderStyle 5#      �� 5$       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5%      ��  �� Property � �� �� Value
 � � �63   �� 5&       � ��
 �   �63   �� 5'       � ��$ 1q�68   �� 5(       � ��
 �����64   5)         Columns 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   CanUserReorder .    CanUserResize .    CanUserSort .     
Foreground
 � � �   Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6y      Header$
 Path��6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6�   �� *RelativePath+  5-       .  .  .  
 � � �$
 auto 6y   $ FileName��6�    6�   �� *
FileName+  5.       .  .  .  
 � � �$
 auto 6y   $ Creation​Time��6�    6�   �� *CreationTimeString+  5/       .  .  .  
 � � �$
 auto 6y   $ Last​Access​Time��6�    6�   �� *LastAccessTimeString+  50       .  .  .  
 � � �$
 auto 6y   $ Last​Write​Time��6�    6�   �� *LastWriteTimeString+  51       .  .  .  
 � � �$
 auto 6y   $ Title��6�    6�   �� *Title+  52       .  .  .  
 � � �$
 auto 6y   $ Subject��6�    6�   �� *	Subject+  53       .  .  .  
 � � �$
 auto 6y   $ Author��6�    6�   �� *Author+  54       .  .  .  
 � � �$
 auto 6y   $ Keywords��6�    6�   �� *
Keywords+  55       .  .  .  
 � � �$
 auto 6y   $ 
LastAuthor��6�    6�   �� *
LastAuthor+  56       .  .  .  
 � � �$
 auto 6y   $ LastPrintDate��6�    6�   �� *LastPrintDate+  57       .  .  .  
 � � �$
 auto 6y   $ CreationDate��6�    6�   �� *CreationDate+  58       .  .  .  
 � � �$
 auto 6y   $ Category��6�    6�   �� *
Category+  59       .  .  .  
 � � �$
 auto 6y   $ Company��6�    6�   �� *	Company+5;      5<      5=      