package edu.itvo.mygestordefinanzas.domain.model

data class UserPreferences(
    val name: String = "",
    val email: String = "",
    val age: Int = 0,
    val isLoggedIn: Boolean = false,
    val darkTheme: Boolean = false,
    val notificationsEnabled: Boolean = true
)
