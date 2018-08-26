package com.sates.test.java;

import java.io.FileInputStream;
import java.lang.reflect.Constructor;
import java.net.URL;
import java.net.URLClassLoader;
import java.util.jar.JarEntry;
import java.util.jar.JarInputStream;

public class testcode_instances
{
    public static void create(Class<?> caller)
    {
        String jar_path = caller.getProtectionDomain().getCodeSource().getLocation().getPath();

        try
        {
            JarInputStream jarfile = new JarInputStream(new FileInputStream(jar_path));
            URL[] classLoaderUrls = new URL[]{new URL("file:///"+jar_path)};
            URLClassLoader urlClassLoader = new URLClassLoader(classLoaderUrls);

            while(true)
            {
                JarEntry myjar = jarfile.getNextJarEntry();
                if (null == myjar)
                {
                    break;
                }
                else if (myjar.getName().endsWith(".class"))
                {
                    try {
                        String className = myjar.getName().substring(0, myjar.getName().length() - 6);
                        className = className.replace('/', '.');
                        Class<?> c = urlClassLoader.loadClass(className);
                        if (c.getSuperclass().getName() == "com.sates.test.java.testcode")
                        {
                            Constructor<?> constructor = c.getConstructor();
                            testcode instance = (testcode)(constructor.newInstance());
                            testcode_list.add_testcode(instance);
                        }
                    }
                    catch (Exception e)
                    {
                        System.out.println(e.toString());
                    }
                }
            }
        }
        catch (Exception e)
        {
            System.out.println(e.toString());
        }
    }
}
