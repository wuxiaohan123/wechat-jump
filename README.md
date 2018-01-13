# 微信小程序“跳一跳”辅助程序（简称外挂）

## 摘要
微信小程序“跳一跳”是微信6.6.1版起推出的一款小游戏，点击屏幕控制小跳瓶从一个积木块跳向另一个积木块。跳跃距离与点击屏幕时间成正比。因此可以在电脑端通过程序精确测量两个积木块的距离以及精确模拟点击的时长。本程序不需要额外的物理外挂。本程序也不是全自动外挂，因为利用了人脑对游戏对象的识别（模式识别再强也比不上人脑哇），因为有人脑的参与所以也算保留了部分游戏的乐趣。

## 项目简介
本工程由Visual Studio 2015开发，面向.NET Framework 4.0编译。
如果不想看文件目录，可以[点击这里](./jump/bin/Release/jump.exe)下载可执行文件。

## 原理
在Windows平台，通过调用系统底层API获取鼠标事件、键盘事件以及产生鼠标点击事件，人为地提升游戏准确度（本人最高达到过980分）。

## 运行条件
· Windows 7及以上（.NET 4.0以上）
· 一个可以自电脑端控制手机的软件（至少有显示手机屏幕、模拟屏幕点击这两个功能）
· 一台安卓手机（开启USB调试模式）

## 推荐配置
· 推荐Chrome浏览器的Vysor插件（[点我下载](./Vysor_v1.8.3.crx)），可以在Chrome以及国产的360、QQ浏览器中运行（后两者安装方式自行百度）。

## 运行姿势
0. 将手机连接到电脑，通过Vysor插件可以对手机进行操作。（以下操作均默认在电脑端的控制软件里进行）
1. 打开微信，进入小游戏，点击开始游戏；
2. 运行jump.exe，程序默认不显示界面（最小化在托盘区）；
3. 鼠标瞄准当前小跳瓶的根部中心位置，左手按下Alt + Q组合键，本程序自动记录当前小跳瓶的位置；
4. 鼠标瞄准小跳瓶将要跳到下一个积木块的中心位置，左手按下Alt + W组合键，程序自动计算距离并模拟鼠标左键点击一定时间，小跳瓶向前跳出；
5. 如果落点与预期不符，可在托盘区点击图标调出图形界面，微调跳跃速度常数（数值越大，跳得越远。取值范围0-100，默认值为35）；
6. 重复3-5，直到找到合适的跳跃速度常数，然后拿高分。
