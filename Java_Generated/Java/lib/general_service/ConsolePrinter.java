package general_service;

import general_service.interfaces.IPrinter;

public class ConsolePrinter implements IPrinter {

    @Override
    public void print(Object object) {
        System.out.print(object + "");
    }
}
