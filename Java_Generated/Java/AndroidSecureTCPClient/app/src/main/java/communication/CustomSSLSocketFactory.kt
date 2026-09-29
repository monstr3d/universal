package communication


import javax.net.ssl.SSLContext
import javax.net.ssl.SSLSocketFactory
import java.security.KeyStore
import javax.net.ssl.TrustManagerFactory
import java.io.FileInputStream
import java.security.cert.CertificateFactory
import java.security.cert.X509Certificate
import java.security.cert.Certificate
import javax.net.ssl.X509TrustManager
import java.util.ArrayList
import javax.net.ssl.TrustManager

fun getCustomSSLSocketFactory(
    file: String,
    trustStorePassword: CharArray? = null // For .jks/.p12 files
): SSLSocketFactory
{
    val stream = FileInputStream(file);
    return getCustomSSLSocketFactory(stream, trustStorePassword);
}
fun getCustomSSLSocketFactory(
    certificateFileInputStream: FileInputStream,
    trustStorePassword: CharArray? = null // For .jks/.p12 files
): SSLSocketFactory {
    try {
        // 1. Create a KeyStore
        val keyStore = KeyStore.getInstance(KeyStore.getDefaultType()) // Or "JKS", "PKCS12"

        // Load the keystore (either a password-protected file or raw certificates)
        if (trustStorePassword != null) {
            // Load from a password-protected Keystore file (e.g., .jks, .p12)
            keyStore.load(certificateFileInputStream, trustStorePassword)
        } else {
            // Load individual PEM certificates
            val cf = CertificateFactory.getInstance("X.509")
            val cert = cf.generateCertificate(certificateFileInputStream) as X509Certificate
            keyStore.load(null) // Initialize an empty keystore
            keyStore.setCertificateEntry("myCertAlias", cert) // Add your certificate
        }

        // 2. Initialize TrustManagerFactory with the custom KeyStore
        val trustManagerFactory = TrustManagerFactory.getInstance(TrustManagerFactory.getDefaultAlgorithm())
        trustManagerFactory.init(keyStore)

        // 3. Get TrustManagers
        val trustManagers: Array<TrustManager> = trustManagerFactory.trustManagers

        // 4. Create SSLContext with the custom TrustManagers
        val sslContext = SSLContext.getInstance("TLS")
        sslContext.init(null, trustManagers, null) // KeyManager (null for client certs), TrustManagers, SecureRandom

        // 5. Get the SSLSocketFactory
        return sslContext.socketFactory
    } catch (e: Exception) {
        throw RuntimeException("Failed to create custom SSLSocketFactory", e)
    } finally {
        certificateFileInputStream.close()
    }
}

// Example usage (loading a single PEM certificate):
fun main() {
    try {
        val fileInputStream = FileInputStream("path/to/your/custom.cer") // Replace with your certificate file path
        val customSocketFactory = getCustomSSLSocketFactory(fileInputStream)

        // Now use customSocketFactory to create SSLSockets that trust your certificate
        // val socket = customSocketFactory.createSocket("your.server.com", 443)
        // ...

    } catch (e: Exception) {
        e.printStackTrace()
    }
}