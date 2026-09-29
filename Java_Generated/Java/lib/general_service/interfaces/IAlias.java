package general_service.interfaces;

public interface IAlias {

    String[] getAliasNames();


    Object getAliasType(String name);

    Object  getAliasValue(String name);

    void setAliasValue(String name, Object obj);

}
