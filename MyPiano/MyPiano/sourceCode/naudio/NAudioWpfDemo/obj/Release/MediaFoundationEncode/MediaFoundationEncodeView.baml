   M S B A M L   `   `   `  ����   NAudioWpfDemoC    =NAudioWpfDemo.MediaFoundationEncode.MediaFoundationEncodeView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .��� .+��� $��Encode��$
��Left=�$��129,292,0,0q�$	��Top=�$��75������ *EncodeCommand+�� $����Demonstrates using Media Foundation to Encode audio from PCM. Requires Windows Vista and above, and depends on the necessary encoders being installed on your PC. Currently a work in progress, do not rely on this.��$
��Left=�$��	10,10,0,0q�$	��Top=�$��57��$
��Wrap=��� $��129,135,49,0q�$	��Top=����� *OutputFormats+  �� SelectedItem  �� *SelectedOutputFormat+ �� Mode$ TwoWay=����� .R��� ���� *Name+�� $��129,162,49,0q�$	��Top=����� *SupportedMediaTypes+  �� *SelectedMediaType+$ TwoWay=����� .R��� ���� *Name+�� $��98��$��129,189,49,0q� �� TextWrapping$
 Wrap=�$	��Top=� �� AcceptsReturn .  �� 
IsReadOnly . ���� *SelectedMediaType.Description+�� $��Input File:��$
��Left=�$��	10,72,0,0q�$	��Top=��� $��23��$��129,75,49,0q�$ NoWrap=�$	��Top=� . ���� *	InputFile+�� $	��...��$��	0,75,10,0q�$	��Top=�$��Right=�$��34������ *SelectInputFileCommand+�� $��Encoding Format:��$
��Left=�$��
10,131,0,0q�$	��Top=��� $��Input PCM Format:��$
��Left=�$��
10,104,0,0q�$	��Top=��� $��23��$��129,107,49,0q�$
 Wrap=�$	��Top=� . ���� *InputFormat+�� $��Encoder Settings:��$
��Left=�$��
10,162,0,0q�$	��Top=�