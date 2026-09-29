package communication

import javax.net.ssl.SSLContext
import javax.net.ssl.SSLSocketFactory
import javax.net.ssl.X509TrustManager
import java.security.cert.X509Certificate
import java.security.KeyStore
import javax.net.ssl.TrustManagerFactory

class CustomTrustManager : X509TrustManager {
    private val defaultTrustManager: X509TrustManager

    init {
        // Initialize a default TrustManager from the system's trust store
        val keyStore = KeyStore.getDefaultType()
        val kmf = TrustManagerFactory.getInstance(TrustManagerFactory.getDefaultAlgorithm())
        kmf.init(null as KeyStore?) // Use system's trust store
        val tms = kmf.trustManagers
        defaultTrustManager = tms.first { it is X509TrustManager } as X509TrustManager
    }

    override fun checkClientTrusted(chain: Array<out X509Certificate>?, authType: String?) {
        // If you need to trust specific client certificates, implement here.
        // For most server-side connections, this is not used.
        defaultTrustManager.checkClientTrusted(chain, authType)
    }

    override fun checkServerTrusted(chain: Array<out X509Certificate>?, authType: String?) {
        // Implement your custom server certificate validation logic here.
        // For example, you could check if the certificate's issuer is trusted
        // or if it matches a pinned certificate.

        // For demonstration, we'll delegate to the default TrustManager
        // but you'd replace this with your custom logic.
        defaultTrustManager.checkServerTrusted(chain, authType)

        // Example: Pinning a specific certificate (simplified)
        // if (chain != null && chain.isNotEmpty()) {
        //     val serverCert = chain[0]
        //     val pinnedCertFingerprint = "YOUR_PINNED_CERT_SHA256_FINGERPRINT"
        //     val actualFingerprint = bytesToHex(MessageDigest.getInstance("SHA-256").digest(serverCert.encoded))
        //     if (actualFingerprint.equals(pinnedCertFingerprint, ignoreCase = true)) {
        //         println("Certificate pinned successfully!")
        //     } else {
        //         throw java.security.cert.CertificateException("Certificate pinning failed.")
        //     }
        // }
    }

    override fun getAcceptedIssuers(): Array<X509Certificate> {
        return defaultTrustManager.acceptedIssuers
    }
}

fun getCustomSSLSocketFactoryWithCustomTrustManager(): SSLSocketFactory {
    try {
        val tt = arrayOf(CustomTrustManager())
        val sslContext = SSLContext.getInstance("TLS")
        sslContext.init(null, arrayOf(CustomTrustManager()), null)
        return sslContext.socketFactory
    } catch (e: Exception) {
        throw RuntimeException("Failed to create SSLSocketFactory with custom TrustManager", e)
    }
}

// Helper for certificate pinning example
// fun bytesToHex(bytes: ByteArray): String {
//     return bytes.joinToString("") { "%02x".format(it) }
// }

// Example usage:
