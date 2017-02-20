框架说明


House.Shell 主程序。启动窗体部分，应用程序的外壳，没有什么实际的内容，
主要验证登陆界面返回的结果，如果结果正确，继续执行，登陆窗如果关闭，那么退出应用程序

House.Thems	主题。包括颜色、按钮的样式等

House.Utility	工具。包括日志组件、配置文件操作、自定义基类


Modules	模块文件夹下面主要各个模块，各个模块单独一个项目，可以重用

House.BigHeader	页头。可重用

House.Footer	页脚。底部的手机下载

House.HeaderNews	头部的跑马灯，各个界面可以重用这个模块

House.Login	登陆模块。忘记密码注册都放在这个项目里面

House.MainMenu	主菜单。中间的十个大按钮

House.MainModule	主模块。House.Shell内关联主模块即可，其他具体功能，有主模块向下分级组织

House.Models	公用的实体类模块

House.NewHouse	新房模块

House.UserControls	用户控件。可以放置一些小的共同控件。或者单独建立项目放置自定义控件也可

House.UserInfo	用户信息模块。可重用



其他说明
每个模块里面有ViewModels、Views文件夹，分别放置对应的ViewModel和View文件内容，可以按照此结构放置。
特殊情况也可不按照此方式，采用codebehind方式。
ViewModel和View的继承结构可以参考已有代码。

新建模块或者项目是，需要引用的内容可以参看已有项目。第三方项目引用请使用nuget方式添加引用

生成的exe和dll文件都在根目录的bin下面



