package edu.itvo.mygestordefinanzas.domain.usecase

import edu.itvo.mygestordefinanzas.domain.model.UserPreferences
import edu.itvo.mygestordefinanzas.domain.repository.UserRepository
import kotlinx.coroutines.flow.first
import javax.inject.Inject

class LoginUseCase @Inject constructor(
    private val repository: UserRepository
) {
    suspend operator fun invoke(
        name: String,
        email: String,
        age: Int
    ) {
        val currentPreferences = repository
            .getUserPreferences()
            .first()

        repository.saveUserPreferences(
            currentPreferences.copy(
                name = name,
                email = email,
                age = age,
                isLoggedIn = true
            )
        )
    }
}
