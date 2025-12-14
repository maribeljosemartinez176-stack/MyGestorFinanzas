plugins {
    id("com.android.application")
    id("org.jetbrains.kotlin.android")
    id("org.jetbrains.kotlin.plugin.serialization")
    id("kotlin-kapt")
    id("dagger.hilt.android.plugin")
}

android {
    namespace = "edu.itvo.mygestordefinanzas"
    compileSdk = 36

    defaultConfig {
        applicationId = "edu.itvo.mygestordefinanzas"
        minSdk = 24
        targetSdk = 36
        versionCode = 1
        versionName = "1.0"

        testInstrumentationRunner = "androidx.test.runner.AndroidJUnitRunner"
    }

    buildTypes {
        release {
            isMinifyEnabled = false
            proguardFiles(
                getDefaultProguardFile("proguard-android-optimize.txt"),
                "proguard-rules.pro"
            )
        }
    }
    compileOptions {
        sourceCompatibility = JavaVersion.VERSION_17
        targetCompatibility = JavaVersion.VERSION_17
    }
    kotlinOptions {
        jvmTarget = "17"
    }
    buildFeatures {
        compose = true
    }
    composeOptions {
        kotlinCompilerExtensionVersion = "1.5.12"
    }
}
configurations.all {
    resolutionStrategy {
        // Fuerza a que todas las dependencias usen la versión 1.12.0
        // en lugar de la 1.12.1 que no existe, resolviendo el conflicto.
        force("androidx.core:core-ktx:1.12.0")
    }
}

dependencies {
// === AndroidX Core & Lifecycle ===
    implementation("androidx.core:core-ktx:1.12.1") // O usar 1.12.0 si quieres lo más reciente
    implementation("androidx.lifecycle:lifecycle-runtime-ktx:2.6.2")
    implementation("androidx.activity:activity-compose:1.8.2")
    implementation(libs.androidx.foundation.layout) // O usar 1.8.2 si quieres lo más reciente

    // === Compose (Usando BOM para gestionar versiones) ===
    // Nota: Se usará la versión 2023.10.01 del BOM por ser más reciente
    val composeBom = platform("androidx.compose:compose-bom:2023.10.01")
    implementation(composeBom)
    androidTestImplementation(composeBom)

    implementation("androidx.compose.ui:ui")
    implementation("androidx.compose.ui:ui-graphics")
    implementation("androidx.compose.ui:ui-tooling-preview")
    // Se mantiene material3:1.2.0, aunque el BOM lo podría gestionar
    implementation("androidx.compose.material3:material3:1.2.0")
    debugImplementation("androidx.compose.ui:ui-tooling")
    debugImplementation("androidx.compose.ui:ui-test-manifest")

    // === Testing ===
    testImplementation("junit:junit:4.13.2")
    androidTestImplementation("androidx.test.ext:junit:1.1.5")
    androidTestImplementation("androidx.test.espresso:espresso-core:3.5.1")
    androidTestImplementation("androidx.compose.ui:ui-test-junit4")

    // === Persistence (Room) ===
    implementation("androidx.room:room-runtime:2.6.0")
    kapt("androidx.room:room-compiler:2.6.0")
    implementation("androidx.room:room-ktx:2.6.0") // Room con soporte para Coroutines

    // === Lifecycle & ViewModel ===
    implementation("androidx.lifecycle:lifecycle-viewmodel-ktx:2.6.2")
    implementation("androidx.lifecycle:lifecycle-livedata-ktx:2.6.2")

    // === Coroutines ===
    implementation("org.jetbrains.kotlinx:kotlinx-coroutines-android:1.7.3")

    // === Dependency Injection (Hilt) ===
    implementation("androidx.hilt:hilt-navigation-compose:1.1.0")
    implementation("com.google.dagger:hilt-android:2.47")
    kapt("com.google.dagger:hilt-compiler:2.47")

    // === DataStore & RecyclerView & Charts ===
    implementation("androidx.datastore:datastore-preferences:1.0.0")
    implementation("androidx.recyclerview:recyclerview:1.3.1")
    implementation("com.github.PhilJay:MPAndroidChart:v3.1.0")
    implementation("androidx.navigation:navigation-compose:2.7.7")

}
