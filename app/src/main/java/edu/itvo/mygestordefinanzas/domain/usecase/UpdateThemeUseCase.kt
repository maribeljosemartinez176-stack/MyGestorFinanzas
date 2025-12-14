package edu.itvo.mygestordefinanzas.domain.usecase

import edu.itvo.mygestordefinanzas.domain.model.UserPreferences
import edu.itvo.mygestordefinanzas.domain.repository.UserRepository
import kotlinx.coroutines.flow.first
import javax.inject.Inject

class UpdateThemeUseCase @Inject constructor(
    private val repository: UserRepository
) {
    suspend operator fun invoke(isDarkTheme: Boolean) {
        repository.saveUserPreferences(
            repository.getUserPreferences()
                .first()
                .copy(darkTheme = isDarkTheme)
        )
        }
    }

