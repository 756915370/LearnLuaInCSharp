# LearnLuaInCSharp
Lua是用C写的编程语言，它提供了一系列的API供用户可以在C里面调用，详见[参考手册](http://cloudwu.github.io/lua53doc/contents.html)

在unity使用的xlua或者tolua等lua都是对Lua进行了封装，帮我们搭好C#到Lua这个桥梁。导致很多人根本不知道lua底层到底是怎么跟其它语言交互的。~~比如我之前就被面试官问了这方面的知识，当时没答上来。~~ 为了让我们更好的掌握Lua，从而不停留在只会用轮子的阶段。我写了这系列博客。

这个工程是我的博客的演示工程，使用的版本是unity2019.3.0 。其中lua的dll是自己打包的，自己还扩展了一些方法，扩展的方法在jlua.c这个文件。lua工程的源代码在/src 文件夹下。    
如果使用的是其它版本的unity，请自行修复报错。
博客地址:  
[【Lua与C#交互（一）】Lua中的栈](https://blog.csdn.net/j756915370/article/details/105779176)  
[【Lua与C#交互（二）】加载Lua文件](https://blog.csdn.net/j756915370/article/details/105846924)  
[【Lua与C#交互（三）】方法调用和错误处理函数](https://blog.csdn.net/j756915370/article/details/105906839)   
[【Lua与C#交互（四）】如何让Lua打印到Unity控制台](https://blog.csdn.net/j756915370/article/details/106799112)  
[【Lua与C#交互（五）】Lua中的注册表和引用系统](https://blog.csdn.net/j756915370/article/details/106875122)  
