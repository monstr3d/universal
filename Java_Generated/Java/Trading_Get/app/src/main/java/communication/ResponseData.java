package communication;


import com.google.gson.annotations.SerializedName;

public class ResponseData {

    @SerializedName("body")
    private String body;

    @SerializedName("id")
    private int id;

    @SerializedName("title")
    private String title;

    @SerializedName("userId")
    private int userId;

    public ResponseData(String body, int id, String title, int userId) {
        this.body = body;
        this.id = id;
        this.title = title;
        this.userId = userId;
    }

    public String getBody() {
        return body;
    }

    public void setBody(String body) {
        this.body = body;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public int getUserId() {
        return userId;
    }

    public void setUserId(int userId) {
        this.userId = userId;
    }
}