#include "framework.h"

#define WINDOW_LIBRARY_EXPORTS

#include "WindowLibrary.h"
#include "MainWindow.h"

MainWindow win;

HWND __cdecl CreateWindowCore(int width, int height, HWND hWndParent)
{
    if (!win.Create(
        L"Learn to Program Windows", 
        WS_CHILDWINDOW, //Style
        0, //ExStyle
        CW_USEDEFAULT,
        CW_USEDEFAULT,
        CW_USEDEFAULT,
        CW_USEDEFAULT,
        hWndParent))
    {
        return 0;
    }
    return win.Window();
}
bool __cdecl DestroyWindowCore(HWND hwnd)
{
    return (win.Close() == TRUE) ? true: false;
}
