package general_service;

import general_service.interfaces.IAliasName;
import general_service.interfaces.IInitialValue;
import general_service.interfaces.IValue;

public class AliasInitialValue implements IInitialValue {

    protected Performer performer = new Performer();

    public AliasInitialValue(IAliasName alias, IValue value) {
        this.alias = alias;
        this.value = value;
    }

    @Override
    public Object getInitValue() {
        return value.getIValue();
    }

    @Override
    public void resetInitValue() {
        var x = alias.getAliasNameValue();
        value.setIValue(x);
    }

    protected IAliasName alias;

    protected IValue value;


}